// ***********************************************************************
// Assembly         : FrederickNguyen.Infrastructure
// Author           : thangnd
// Created          : 06-20-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-22-2018
// ***********************************************************************
// <copyright file="CustomerRepository.cs" company="FrederickNguyen.Infrastructure">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Repository;
using FrederickNguyen.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FrederickNguyen.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Class CustomerRepository.
    /// </summary>
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CustomerRepository(FrederickContext dbContext)
            : base(dbContext)
        {
        }

        /// <summary>
        /// Finds the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Customer.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Customer FindByEmail(string email)
        {
            return FrederickContext.Customers.AsNoTracking().FirstOrDefault(c => c.Email.Equals(email));
        }

        /// <summary>
        /// Finds the one.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Customer.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Customer FindOne(Guid id)
        {
            //AsNoTracking -> khi lấy xong sẽ ko đẩy lên memory tránh trường hợp tạo mới 1 đối tượng trùng id
            return FrederickContext.Customers.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Updates the without email and password.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateWithoutEmailAndPassword(Customer customer)
        {
            var customerEntry = FrederickContext.Entry(customer);
            customerEntry.Property("FirstName").IsModified = true;
            customerEntry.Property("LastName").IsModified = true;
            customerEntry.Property("CountryId").IsModified = true;
        }
    }
}
