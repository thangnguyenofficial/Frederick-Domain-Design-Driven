// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 06-18-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-18-2018
// ***********************************************************************
// <copyright file="Customer.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using FrederickNguyen.DomainCore.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Countries;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models
{
    /// <summary>
    /// Class Customer.
    /// </summary>
    public class Customer : Entity, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public virtual string FirstName { get; protected set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public virtual string LastName { get; protected set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public virtual string Email { get; protected set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public virtual string PasswordHash { get; protected set; }

        /// <summary>
        /// Gets or sets the security stamp.
        /// </summary>
        /// <value>The security stamp.</value>
        public virtual string SecurityStamp { get; protected set; }

        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>The country identifier.</value>
        public virtual Guid CountryId { get; protected set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        public virtual  decimal Balance { get; protected set; }

        /// <summary>
        /// Creates the specified first name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="securityStamp">The security stamp.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <param name="country">The country.</param>
        /// <returns>Customer.</returns>
        public static Customer Create(string firstName, string lastName, string email, string securityStamp, string passwordHash, Country country)
        {
            return Create(Guid.NewGuid(), firstName, lastName, email, securityStamp, passwordHash, country);
        }

        /// <summary>
        /// Creates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="securityStamp">The security stamp.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <param name="country">The country.</param>
        /// <returns>Customer.</returns>
        public static Customer Create(Guid id, string firstName, string lastName, string email, string securityStamp, string passwordHash, Country country)
        {
            var customer = new Customer
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                CountryId = country.Id,
                PasswordHash = passwordHash,
                SecurityStamp = securityStamp,
                Balance = 0
            };

            return customer;
        }

        /// <summary>
        /// Updates the without email and password.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="country">The country.</param>
        /// <returns>Customer.</returns>
        public static Customer UpdateWithoutEmailAndPassword(Guid id, string firstName, string lastName, Country country)
        {
            var customer = new Customer
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                CountryId = country.Id
            };

            return customer;
        }
    }
}
