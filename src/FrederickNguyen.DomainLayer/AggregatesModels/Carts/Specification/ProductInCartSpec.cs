// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-17-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-17-2018
// ***********************************************************************
// <copyright file="ProductInCartSpec.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainCore.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Carts.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Carts.Specification
{
    /// <summary>
    /// Class ProductInCartSpec.
    /// </summary>
    public class ProductInCartSpec : SpecificationBase<CartProduct>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductInCartSpec"/> class.
        /// </summary>
        /// <param name="product">The product.</param>
        public ProductInCartSpec(Product product) : base(p => p.ProductId == product.Id)
        {
        }
    }
}
