// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-19-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-19-2018
// ***********************************************************************
// <copyright file="CustomerCheckOut.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainCore.Events;
using FrederickNguyen.DomainLayer.AggregatesModels.Purchases.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Events
{
    /// <summary>
    /// Class CustomerCheckOutEvent.
    /// </summary>
    public class CustomerCheckOutEvent : DomainEvent
    {
        /// <summary>
        /// Gets or sets the purchase.
        /// </summary>
        /// <value>The purchase.</value>
        public Purchase Purchase { get; set; }

        /// <summary>
        /// Flattens this instance.
        /// </summary>
        public override void Flatten()
        {
            Args.Add("CustomerId", Purchase.CustomerId);
            Args.Add("PurchaseId", Purchase.Id);
            Args.Add("TotalCost", Purchase.TotalPrice);
            Args.Add("NumberOfProducts", Purchase.Products.Count);
        }
    }
}
