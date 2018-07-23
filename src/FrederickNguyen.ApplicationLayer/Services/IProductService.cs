// ***********************************************************************
// Assembly         : FrederickNguyen.ApplicationLayer
// Author           : thangnd
// Created          : 07-12-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-12-2018
// ***********************************************************************
// <copyright file="IProductService.cs" company="FrederickNguyen.ApplicationLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using FrederickNguyen.ApplicationLayer.DataTransferObjects;
using FrederickNguyen.ApplicationLayer.Models;

namespace FrederickNguyen.ApplicationLayer.Services
{
    /// <summary>
    /// Interface IProductService
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>ProductDto.</returns>
        ProductDto GetProductById(Guid productId);

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Add(AddNewProductViewModel model);
    }
}
