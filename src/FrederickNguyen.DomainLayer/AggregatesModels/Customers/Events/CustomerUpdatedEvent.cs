// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-10-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-10-2018
// ***********************************************************************
// <copyright file="CustomerUpdatedEvent.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainCore.Events;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Events
{
    public class CustomerUpdatedEvent : DomainEvent
    {
        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public Customer Customer { get; set; }

        /// <summary>
        /// Flattens this instance.
        /// </summary>
        public override void Flatten()
        {
            Args.Add("FirstName", Customer.FirstName);
            Args.Add("LastName", Customer.LastName);
            Args.Add("Country", Customer.CountryId);
        }
    }
}
