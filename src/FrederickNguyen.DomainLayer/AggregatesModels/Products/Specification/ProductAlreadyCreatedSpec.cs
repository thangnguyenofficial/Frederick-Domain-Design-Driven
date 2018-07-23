// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-14-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-14-2018
// ***********************************************************************
// <copyright file="ProductAlreadyCreatedSpec.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainCore.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Products.Specification
{
    /// <summary>
    /// Class ProductAlreadyCreatedSpec. This class cannot be inherited.
    /// </summary>
    public sealed class ProductAlreadyCreatedSpec : SpecificationBase<Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAlreadyCreatedSpec" /> class.
        /// </summary>
        /// <param name="code">The code.</param>
        public ProductAlreadyCreatedSpec(string code) : base(c => c.Code == code)
        {
        }
    }
}
