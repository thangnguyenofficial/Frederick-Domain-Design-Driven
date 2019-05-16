// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-05-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="CustomerCreatedEvents.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainCore.Events;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;
using MediatR;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Events
{
    /// <summary>
    /// Class CustomerRemovedEvent.
    /// </summary>
    public class CustomerRemovedEvent : DomainEvent
    {
        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public Customer Customer { get; set; }

        /// <summary>
        /// Flattens this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void Flatten()
        {
            Args.Add("FirstName", Customer.FirstName);
            Args.Add("LastName", Customer.LastName);
            Args.Add("Email", Customer.Email);
        }
    }
}
