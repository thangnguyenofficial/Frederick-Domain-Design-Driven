// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 06-20-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-20-2018
// ***********************************************************************
// <copyright file="ICustomerRepository.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using FrederickNguyen.DomainCore.Repository;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Repository
{
    /// <summary>
    /// Interface ICustomerRepository
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// Finds the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Customer.</returns>
        Customer FindByEmail(string email);

        /// <summary>
        /// Finds the one.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Customer.</returns>
        Customer FindOne(Guid id);

        /// <summary>
        /// Updates the without email and password.
        /// </summary>
        /// <param name="customer">The customer.</param>
        void UpdateWithoutEmailAndPassword(Customer customer);
    }
}
