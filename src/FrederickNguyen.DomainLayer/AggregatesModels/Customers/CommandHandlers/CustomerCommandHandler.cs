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
using FrederickNguyen.DomainCore.Events;
using FrederickNguyen.DomainCore.Notification;
using FrederickNguyen.DomainCore.Repository;
using FrederickNguyen.DomainCore.UnitOfWork;
using FrederickNguyen.DomainLayer.AggregatesModels.Countries;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Commands;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Events;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Repository;
using MediatR;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.CommandHandlers
{
    /// <summary>
    /// Class CustomerCommandHandler.
    /// </summary>
    public class CustomerCommandHandler : IRequestHandler<CreateCustomerCommand>, IRequestHandler<UpdateCustomerCommand>, IRequestHandler<RemoveCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCommandHandler" /> class.
        /// </summary>
        /// <param name="customerRepository">The customer repository.</param>
        /// <param name="countryRepository">The country repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="eventDispatcher">The event dispatcher.</param>
        public CustomerCommandHandler(ICustomerRepository customerRepository, IRepository<Country> countryRepository, IUnitOfWork unitOfWork,
            IEventDispatcher eventDispatcher)
        {
            _customerRepository = customerRepository;
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
            _eventDispatcher = eventDispatcher;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors)
                    _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, error.ErrorMessage));
                return Task.CompletedTask;
            }

            var country = _countryRepository.FindById(request.CountryId);
            if (country == null)
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"Country id does not exit in system"));
                return Task.CompletedTask;
            }

            var customer = Customer.Create(request.FirstName, request.LastName, request.Email, request.SecurityStamp, request.PasswordHash, country);

            var existingCustomer = _customerRepository.FindByEmail(customer.Email);
            if (existingCustomer != null)
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"The customer e-mail has already been taken"));
                return Task.CompletedTask;
            }

            //add customer
            var customerAdded = _customerRepository.Add(customer);
            if (customerAdded == null)
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"new customer could not insert"));
                return Task.CompletedTask;
            }
            _unitOfWork.Commit();

            //raise events send email & store event
            _eventDispatcher.RaiseEvent(new CustomerCreatedEvent { Customer = customerAdded });

            return Task.CompletedTask;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors)
                    _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, error.ErrorMessage));
                return Task.CompletedTask;
            }

            var country = _countryRepository.FindById(request.CountryId);
            if (country == null)
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"Country id does not exit in system"));
                return Task.CompletedTask;
            }

            var existingCustomer = _customerRepository.FindOne(request.Id);
            if (existingCustomer == null)
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"The customer does not exit in system"));
                return Task.CompletedTask;
            }

            //edit customer
            var customer = Customer.UpdateWithoutEmailAndPassword(request.Id, request.FirstName, request.LastName, country);
            _customerRepository.UpdateWithoutEmailAndPassword(customer);
            _unitOfWork.Commit();

            _eventDispatcher.RaiseEvent(new CustomerUpdatedEvent { Customer = customer });

            return Task.CompletedTask;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public Task Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors)
                    _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, error.ErrorMessage));
                return Task.CompletedTask;
            }

            var existingCustomer = _customerRepository.FindOne(request.Id);
            if (existingCustomer == null)
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"The customer does not exit in system"));
                return Task.CompletedTask;
            }

            //remove customer
            _customerRepository.Delete(existingCustomer);
            _unitOfWork.Commit();

            return Task.CompletedTask;
        }
    }
}
