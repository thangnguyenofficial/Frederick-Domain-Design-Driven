// ***********************************************************************
// Assembly         : FrederickNguyen.ApplicationLayer
// Author           : thangnd
// Created          : 06-20-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-20-2018
// ***********************************************************************
// <copyright file="CustomerService.cs" company="FrederickNguyen.ApplicationLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using AutoMapper;
using FrederickNguyen.ApplicationLayer.DataTransferObjects;
using FrederickNguyen.ApplicationLayer.Models;
using FrederickNguyen.DomainCore.Commands;
using FrederickNguyen.DomainCore.Repository;
using FrederickNguyen.DomainCore.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Commands;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Repository;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Purchases.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Purchases.Specification;
using FrederickNguyen.Infrastructure.Components.Cryptography;

namespace FrederickNguyen.ApplicationLayer.Services
{
    /// <summary>
    /// Class CustomerService.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IRepository<Purchase> _purchaseRepository;
        private readonly IRepository<PurchasedProduct> _purchaseProductRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="customerRepository">The customer repository.</param>
        /// <param name="commandDispatcher">The command dispatcher.</param>
        /// <param name="purchaseProductRepository">The purchase product repository.</param>
        /// <param name="purchaseRepository">The purchase repository.</param>
        public CustomerService(IMapper mapper, ICustomerRepository customerRepository, ICommandDispatcher commandDispatcher,
            IRepository<PurchasedProduct> purchaseProductRepository, IRepository<Purchase> purchaseRepository)
        {
            _mapper = mapper;
            _purchaseRepository = purchaseRepository;
            _customerRepository = customerRepository;
            _commandDispatcher = commandDispatcher;
            _purchaseProductRepository = purchaseProductRepository;
        }

        /// <summary>
        /// Determines whether [is email available] [the specified email].
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns><c>true</c> if [is email available] [the specified email]; otherwise, <c>false</c>.</returns>
        public bool IsEmailAvailable(string email)
        {
            ISpecification<Customer> alreadyRegisteredSpec = new CustomerAlreadyRegisteredSpec(email);

            var existingCustomer = _customerRepository.FindSingleBySpec(alreadyRegisteredSpec);
            return existingCustomer == null;
        }

        /// <summary>
        /// Gets the customer by identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>CustomerDto.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public CustomerDto GetCustomerById(Guid customerId)
        {
            var customer = _customerRepository.FindById(customerId);
            return _mapper.Map<CustomerDto>(customer);
        }

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Add(AddNewCustomerViewModel model)
        {
            const int saltLength = 64;
            var createCustomerCommand = _mapper.Map<CreateCustomerCommand>(model);
            var passwordResult = PasswordWithSaltHasher.ActionEncrypt(model.Password, saltLength);

            createCustomerCommand.SecurityStamp = passwordResult.Salt;
            createCustomerCommand.PasswordHash = passwordResult.Digest;

            _commandDispatcher.Send(createCustomerCommand);
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(UpdateCustomerViewModel model)
        {
            var updateCustomerCommand = _mapper.Map<UpdateCustomerCommand>(model);
            _commandDispatcher.Send(updateCustomerCommand);
        }

        /// <summary>
        /// Removes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Remove(RemoveCustomerViewModel model)
        {
            var removeCustomerCommand = _mapper.Map<RemoveCustomerCommand>(model);
            _commandDispatcher.Send(removeCustomerCommand);
        }

        /// <summary>
        /// Gets the customer purchase history.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>CustomerPurchaseHistoryDto.</returns>
        public CustomerPurchaseHistoryDto GetCustomerPurchaseHistory(Guid customerId)
        {
            var customer = _customerRepository.FindById(customerId);
            if (customer == null) return null;

            var customerPurchases = _purchaseRepository.Find(new CustomerPurchasesSpec(customer.Id)).ToList();
            foreach (var customerPurchase in customerPurchases)
            {
                customerPurchase.Products = _purchaseProductRepository.Find(new PurchasedProductsSpec(customerPurchase.Id)).ToList();
            }
            var customerPurchaseHistory = new CustomerPurchaseHistoryDto
            {
                CustomerId = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                TotalPurchases = customerPurchases.Count,
                TotalProductsPurchased = customerPurchases.Sum(purchase => purchase.Products.Sum(product => product.Quantity)),
                TotalPrice = customerPurchases.Sum(purchase => purchase.TotalPrice)
            };
            return customerPurchaseHistory;
        }
    }
}
