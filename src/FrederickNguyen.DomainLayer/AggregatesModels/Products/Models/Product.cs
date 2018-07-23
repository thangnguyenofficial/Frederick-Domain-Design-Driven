// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-12-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-12-2018
// ***********************************************************************
// <copyright file="Product.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FrederickNguyen.DomainCore.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Products.Models
{
    /// <summary>
    /// Class Product.
    /// </summary>
    public class Product : Entity, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public virtual string Code { get; protected set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public virtual DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>The modified date.</value>
        public virtual DateTime ModifiedDate { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public virtual bool IsActive { get; protected set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public virtual int Quantity { get; protected set; }

        /// <summary>
        /// Gets or sets the cost price.
        /// </summary>
        /// <value>The cost price.</value>
        public virtual decimal Cost { get; protected set; }

        /// <summary>
        /// Creates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="code">The code.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="costPrice">The cost price.</param>
        /// <returns>Product.</returns>
        public static Product Create(string name, string code, int quantity, decimal costPrice)
        {
            return Create(Guid.NewGuid(), name, code, quantity, costPrice);
        }

        /// <summary>
        /// Creates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="code">The code.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="costPrice">The cost price.</param>
        /// <returns>Product.</returns>
        public static Product Create(Guid id, string name, string code, int quantity, decimal costPrice)
        {
            var product = new Product
            {
                Id = id,
                Name = name,
                Code = code,
                Quantity = quantity,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                Cost = costPrice
            };

            return product;
        }
    }
}
