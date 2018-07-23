// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 06-20-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-20-2018
// ***********************************************************************
// <copyright file="CustomerAlreadyRegisteredSpec.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainCore.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Specification
{
    /// <summary>
    /// Class CustomerAlreadyRegisteredSpec.
    /// </summary>
    public sealed class CustomerAlreadyRegisteredSpec : SpecificationBase<Customer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAlreadyRegisteredSpec"/> class.
        /// </summary>
        /// <param name="email">The email.</param>
        public CustomerAlreadyRegisteredSpec(string email)
            : base(b => b.Email == email)
        {
        }
    }
}
