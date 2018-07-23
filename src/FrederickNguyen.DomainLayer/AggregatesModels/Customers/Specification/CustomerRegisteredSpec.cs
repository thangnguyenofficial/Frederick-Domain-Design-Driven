// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-06-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="CustomerRegisteredSpec.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using FrederickNguyen.DomainCore.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Specification
{
    public class CustomerRegisteredSpec : SpecificationBase<Customer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRegisteredSpec"/> class.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerRegisteredSpec(Guid customerId) : base(b => b.Id == customerId)
        {
        }
    }
}
