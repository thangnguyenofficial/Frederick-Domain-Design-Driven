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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FrederickNguyen.DomainCore.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Events;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Specification;
using FrederickNguyen.DomainLayer.Exceptions;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models
{
    /// <summary>
    /// Class Customer.
    /// </summary>
    public class Customer : Entity, IAggregateRoot
    {
        private readonly List<CreditCard> _creditCards = new List<CreditCard>();

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; protected set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; protected set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; protected set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string PasswordHash { get; protected set; }

        /// <summary>
        /// Gets or sets the security stamp.
        /// </summary>
        /// <value>The security stamp.</value>
        public string SecurityStamp { get; protected set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        public decimal Balance { get; protected set; }

        /// <summary>
        /// Gets the credit cards.
        /// </summary>
        /// <value>The credit cards.</value>
        public ReadOnlyCollection<CreditCard> CreditCards => _creditCards.AsReadOnly();

        /// <summary>
        /// Creates the specified first name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="securityStamp">The security stamp.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <exception cref="CustomerDomainException">
        /// firstName
        /// or
        /// lastName
        /// or
        /// email
        /// </exception>
        /// <returns>Customer.</returns>
        public Customer(string firstName, string lastName, string email, string securityStamp, string passwordHash)
        {
            if (string.IsNullOrEmpty(firstName)) throw new CustomerDomainException(nameof(firstName));
            if (string.IsNullOrEmpty(lastName)) throw new CustomerDomainException(nameof(lastName));
            if (string.IsNullOrEmpty(email)) throw new CustomerDomainException(nameof(email));

            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            SecurityStamp = securityStamp;
            Balance = 0;

            AddDomainEvent(new CustomerCreatedEvent { Customer = this });
        }

        /// <summary>
        /// Adds the specified credit card.
        /// </summary>
        /// <param name="creditCard">The credit card.</param>
        public virtual void Add(CreditCard creditCard)
        {
            if (CreditCards.Contains(creditCard)) throw new CustomerDomainException("Can't add same card to the collection");
            _creditCards.Add(creditCard);
        }

        /// <summary>
        /// Gets the credit cards availble.
        /// </summary>
        /// <returns>ReadOnlyCollection&lt;CreditCard&gt;.</returns>
        public virtual ReadOnlyCollection<CreditCard> GetCreditCardsAvailble()
        {
            return _creditCards.FindAll(new CreditCardAvailableSpec(DateTime.Today).IsSatisfiedBy).AsReadOnly();
        }
    }
}
