// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-17-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-17-2018
// ***********************************************************************
// <copyright file="Cart.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FrederickNguyen.DomainCore.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Carts.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Carts.Models
{
    /// <summary>
    /// Class Cart.
    /// </summary>
    public class Cart : Entity, IAggregateRoot
    {
        /// <summary>
        /// The products in cart
        /// </summary>
        private readonly List<CartProduct> _cartProducts = new List<CartProduct>();

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <value>The products.</value>
        public virtual ReadOnlyCollection<CartProduct> Products => _cartProducts.AsReadOnly();

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public virtual Guid CustomerId { get; protected set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public virtual DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets the total price.
        /// </summary>
        /// <value>The total price.</value>
        public virtual decimal TotalPrice
        {
            get { return Products.Sum(cartProduct => cartProduct.Quantity * cartProduct.Cost); }
        }

        /// <summary>
        /// Creates the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>Cart.</returns>
        public static Cart Create(Customer customer)
        {
            var cart = new Cart
            {
                Id = Guid.NewGuid(),
                CustomerId = customer.Id,
                CreatedDate = DateTime.Now
            };

            return cart;
        }

        /// <summary>
        /// Adds the specified cart product.
        /// </summary>
        /// <param name="cartProduct">The cart product.</param>
        public virtual void Add(CartProduct cartProduct)
        {
            _cartProducts.Add(cartProduct);
        }

        /// <summary>
        /// Removes the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        public virtual void Remove(Product product)
        {
            var cartProduct = _cartProducts.Find(new ProductInCartSpec(product).IsSatisfiedBy);
            _cartProducts.Remove(cartProduct);
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public virtual void Clear()
        {
            _cartProducts.Clear();
        }
    }
}
