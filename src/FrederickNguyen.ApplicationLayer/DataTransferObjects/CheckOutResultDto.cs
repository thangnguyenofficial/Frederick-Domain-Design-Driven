// ***********************************************************************
// Assembly         : FrederickNguyen.ApplicationLayer
// Author           : thangnd
// Created          : 07-19-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-19-2018
// ***********************************************************************
// <copyright file="CheckOutResultDto.cs" company="FrederickNguyen.ApplicationLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using FrederickNguyen.DomainLayer.AggregatesModels.Carts.Models;

namespace FrederickNguyen.ApplicationLayer.DataTransferObjects
{
    /// <summary>
    /// Class CheckOutResultDto.
    /// </summary>
    public class CheckOutResultDto
    {
        /// <summary>
        /// Gets or sets the purchase identifier.
        /// </summary>
        /// <value>The purchase identifier.</value>
        public Guid? PurchaseId { get; set; }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>The total price.</value>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the check out issue.
        /// </summary>
        /// <value>The check out issue.</value>
        public CheckOutIssue CheckOutIssue { get; set; }
    }
}
