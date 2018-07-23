// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-17-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-17-2018
// ***********************************************************************
// <copyright file="CustomerCartSpec.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using FrederickNguyen.DomainCore.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Carts.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Carts.Specification
{
    /// <summary>
    /// Class CustomerCartSpec.
    /// </summary>
    public class CustomerCartSpec : SpecificationBase<Cart>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCartSpec"/> class.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerCartSpec(Guid customerId) : base(cart => cart.CustomerId == customerId)
        {
        }
    }
}
