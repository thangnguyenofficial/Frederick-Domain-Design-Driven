// ***********************************************************************
// Assembly         : FrederickNguyen.ApplicationLayer
// Author           : thangnd
// Created          : 07-19-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-19-2018
// ***********************************************************************
// <copyright file="CustomerPurchaseHistoryDto.cs" company="FrederickNguyen.ApplicationLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace FrederickNguyen.ApplicationLayer.DataTransferObjects
{
    /// <summary>
    /// Class CustomerPurchaseHistoryDto.
    /// </summary>
    public class CustomerPurchaseHistoryDto
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the total purchases.
        /// </summary>
        /// <value>The total purchases.</value>
        public int TotalPurchases { get; set; }

        /// <summary>
        /// Gets or sets the total products purchased.
        /// </summary>
        /// <value>The total products purchased.</value>
        public int TotalProductsPurchased { get; set; }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>The total price.</value>
        public decimal TotalPrice { get; set; }
    }
}
