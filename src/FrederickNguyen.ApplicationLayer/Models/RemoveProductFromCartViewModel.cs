// ***********************************************************************
// Assembly         : FrederickNguyen.ApplicationLayer
// Author           : thangnd
// Created          : 07-19-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-19-2018
// ***********************************************************************
// <copyright file="RemoveProductFromCartViewModel.cs" company="FrederickNguyen.ApplicationLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;

namespace FrederickNguyen.ApplicationLayer.Models
{
    /// <summary>
    /// Class RemoveProductFromCartViewModel.
    /// </summary>
    public class RemoveProductFromCartViewModel
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [Required(ErrorMessage = "Customer id is required")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        [Required(ErrorMessage = "Product id is required")]
        public Guid ProductId { get; set; }
    }
}
