// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-23-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-23-2018
// ***********************************************************************
// <copyright file="PurchaseProductsSpec.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainCore.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Purchases.Models;
using System;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Purchases.Specification
{
    /// <summary>
    /// Class PurchasedProductsSpec.
    /// </summary>
    public class PurchasedProductsSpec : SpecificationBase<PurchasedProduct>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchasedProductsSpec"/> class.
        /// </summary>
        /// <param name="purchaseId">The purchase identifier.</param>
        public PurchasedProductsSpec(Guid purchaseId)
          : base(purchasedProduct => purchasedProduct.PurchaseId == purchaseId)
        {
        }
    }
}
