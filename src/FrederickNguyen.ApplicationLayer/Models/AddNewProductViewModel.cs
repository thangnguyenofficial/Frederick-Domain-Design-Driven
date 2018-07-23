// ***********************************************************************
// Assembly         : FrederickNguyen.ApplicationLayer
// Author           : thangnd
// Created          : 07-12-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-12-2018
// ***********************************************************************
// <copyright file="AddNewProductViewModel.cs" company="FrederickNguyen.ApplicationLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;

namespace FrederickNguyen.ApplicationLayer.Models
{
    /// <summary>
    /// Class AddNewProductViewModel.
    /// </summary>
    public class AddNewProductViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required(ErrorMessage = "The product name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Required(ErrorMessage = "The product code is required")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        [Required(ErrorMessage = "quantity is required")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the cost price.
        /// </summary>
        /// <value>The cost price.</value>
        [Required(ErrorMessage = "cost price is required")]
        public decimal Cost { get; set; }
    }
}
