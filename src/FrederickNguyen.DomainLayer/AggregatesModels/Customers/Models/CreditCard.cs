// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 05-15-2019
//
// Last Modified By : thangnd
// Last Modified On : 05-15-2019
// ***********************************************************************
// <copyright file="CreditCard.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using FrederickNguyen.DomainCore.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models
{
    /// <summary>
    /// Class CreditCard.
    /// </summary>
    public class CreditCard : Entity
    {
        /// <summary>
        /// Gets or sets the name on card.
        /// </summary>
        /// <value>The name on card.</value>
        public virtual string NameOnCard { get; protected set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>The card number.</value>
        public virtual string CardNumber { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public virtual bool IsActive { get; protected set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public virtual DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// Gets or sets the expiried date.
        /// </summary>
        /// <value>The expiried date.</value>
        public virtual DateTime ExpiriedDate { get; protected set; }

        /// <summary>
        /// Creates the specified name on card.
        /// </summary>
        /// <param name="nameOnCard">The name on card.</param>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="createdDate">The created date.</param>
        /// <param name="expiriedDate">The expiried date.</param>
        /// <returns>CreditCard.</returns>
        public static CreditCard Create(string nameOnCard, string cardNumber, bool isActive, DateTime createdDate, DateTime expiriedDate)
        {
            return Create(Guid.NewGuid(), nameOnCard, cardNumber, isActive, createdDate, expiriedDate);
        }

        /// <summary>
        /// Creates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="nameOnCard">The name on card.</param>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="createdDate">The created date.</param>
        /// <param name="expiriedDate">The expiried date.</param>
        /// <returns>CreditCard.</returns>
        /// <exception cref="ArgumentNullException">
        /// nameOnCard
        /// or
        /// cardNumber
        /// or
        /// expiriedDate
        /// </exception>
        public static CreditCard Create(Guid id, string nameOnCard, string cardNumber, bool isActive, DateTime createdDate, DateTime expiriedDate)
        {
            if (string.IsNullOrEmpty(nameOnCard)) throw new ArgumentNullException(nameof(nameOnCard));
            if (string.IsNullOrWhiteSpace(cardNumber)) throw new ArgumentNullException(nameof(cardNumber));
            if (expiriedDate < DateTime.UtcNow) throw new ArgumentNullException(nameof(expiriedDate));

            var creditCard = new CreditCard
            {
                Id = id,
                ExpiriedDate = expiriedDate,
                IsActive = isActive,
                CardNumber = cardNumber,
                CreatedDate = createdDate,
                NameOnCard = nameOnCard
            };

            return creditCard;
        }
    }
}
