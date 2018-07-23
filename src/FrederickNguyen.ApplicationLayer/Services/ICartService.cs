// ***********************************************************************
// Assembly         : FrederickNguyen.ApplicationLayer
// Author           : thangnd
// Created          : 07-17-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-17-2018
// ***********************************************************************
// <copyright file="ICartService.cs" company="FrederickNguyen.ApplicationLayer">
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
    /// Interface ICartService
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Gets the by customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>CartDto.</returns>
        CartDto GetProductsInCartByCustomerId(Guid customerId);

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Add(AddProudctToCartViewModel model);

        /// <summary>
        /// Removes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Remove(RemoveProductFromCartViewModel model);

        /// <summary>
        /// Checks the out.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>CheckOutResultDto.</returns>
        CheckOutResultDto CheckOut(Guid customerId);
    }
}
