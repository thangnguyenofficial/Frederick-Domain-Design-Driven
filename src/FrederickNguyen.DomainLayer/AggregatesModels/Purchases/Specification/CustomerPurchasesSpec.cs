// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-20-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-20-2018
// ***********************************************************************
// <copyright file="PurchasedNProductsSpec.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using FrederickNguyen.DomainCore.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Purchases.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Purchases.Specification
{
    /// <summary>
    /// Class PurchasedNProductsSpec.
    /// </summary>
    public class CustomerPurchasesSpec : SpecificationBase<Purchase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerPurchasesSpec"/> class.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerPurchasesSpec(Guid customerId)
            : base(purchase => purchase.CustomerId == customerId)
        {
        }
    }
}
