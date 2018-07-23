// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-19-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-19-2018
// ***********************************************************************
// <copyright file="ProductIsInStockSpec.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainCore.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Carts.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Products.Specification
{
    /// <summary>
    /// Class ProductIsInStockSpec. This class cannot be inherited.
    /// </summary>
    public sealed class ProductIsInStockSpec : SpecificationBase<Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductIsInStockSpec"/> class.
        /// </summary>
        /// <param name="productCart">The product cart.</param>
        public ProductIsInStockSpec(CartProduct productCart)
            : base(product => product.Id == productCart.ProductId && product.IsActive && product.Quantity >= productCart.Quantity)
        {
        }
    }
}
