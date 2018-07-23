// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-14-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-14-2018
// ***********************************************************************
// <copyright file="ProductCreatedEvent.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainCore.Events;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Products.Events
{
    /// <summary>
    /// Class ProductCreatedEvent.
    /// </summary>
    public class ProductCreatedEvent : DomainEvent
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public Product Product { get; set; }

        /// <summary>
        /// Flattens this instance.
        /// </summary>
        public override void Flatten()
        {
            Args.Add("Name", Product.Name);
            Args.Add("Code", Product.Code);
            Args.Add("Quantity", Product.Quantity);
            Args.Add("Cost", Product.Cost);
            Args.Add("IsActive", Product.IsActive);
            Args.Add("ModifiedDate", Product.ModifiedDate);
            Args.Add("CreatedDate", Product.CreatedDate);
        }
    }
}
