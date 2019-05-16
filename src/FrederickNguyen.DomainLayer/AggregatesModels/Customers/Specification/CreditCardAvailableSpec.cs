// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 05-15-2019
//
// Last Modified By : thangnd
// Last Modified On : 05-15-2019
// ***********************************************************************
// <copyright file="CreditCardAvailableSpec.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq.Expressions;
using FrederickNguyen.DomainCore.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Specification
{
    /// <summary>
    /// Class CreditCardAvailableSpec.
    /// </summary>
    public class CreditCardAvailableSpec : SpecificationBase<CreditCard>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardAvailableSpec"/> class.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        public CreditCardAvailableSpec(DateTime dateTime)
            : base(b => b.IsActive == b.ExpiriedDate >= dateTime)
        {
        }
    }
}
