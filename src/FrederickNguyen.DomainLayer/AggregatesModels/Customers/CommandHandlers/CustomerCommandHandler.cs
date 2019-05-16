// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 06-22-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-22-2018
// ***********************************************************************
// <copyright file="CreateCustomerCommandHandler.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading;
using System.Threading.Tasks;
using FrederickNguyen.DomainCore.UnitOfWork;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Commands;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Repository;
using FrederickNguyen.DomainLayer.Exceptions;
using FrederickNguyen.Infrastructure.Components.Cryptography;
using MediatR;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.CommandHandlers
{
    /// <summary>
    /// Class CustomerCommandHandler.
    /// </summary>
    public class CustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>, IRequestHandler<RemoveCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private const int SaltLength = 64;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCommandHandler" /> class.
        /// </summary>
        /// <param name="customerRepository">The customer repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public CustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors) throw new CustomerDomainException(error.ErrorMessage);
                return false;
            }

            //encrypt password
            var passwordResult = PasswordWithSaltHasher.ActionEncrypt(request.Password, SaltLength);
            var customer = new Customer(request.FirstName, request.LastName, request.Email, passwordResult.Salt, passwordResult.Digest);

            var existingCustomer = _customerRepository.FindByEmail(customer.Email);
            if (existingCustomer != null) throw new CustomerDomainException("The customer e-mail has already been taken");

            //add customer
            var customerAdded = _customerRepository.Add(customer);
            if (customerAdded == null) throw new CustomerDomainException("new customer could not insert");
            return await _unitOfWork.CommitAsync(cancellationToken);
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public async Task<bool> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors) throw new CustomerDomainException(error.ErrorMessage);
                return false;
            }

            var existingCustomer = _customerRepository.FindOne(request.Id);
            if (existingCustomer == null) throw new CustomerDomainException(@"The customer does not exit in system");

            //remove customer
            _customerRepository.Delete(existingCustomer);
            return await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
