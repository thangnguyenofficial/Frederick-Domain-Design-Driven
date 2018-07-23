// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-19-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-19-2018
// ***********************************************************************
// <copyright file="ProductState.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using FrederickNguyen.DomainCore.Models;

namespace FrederickNguyen.DomainLayer.Services.Checkout
{
    /// <summary>
    /// Class ProductState.
    /// </summary>
    public class ProductState : Enumeration
    {
        public static ProductState Ok = new ProductState(100, nameof(Ok).ToLowerInvariant());
        public static ProductState NotInStock = new ProductState(201, nameof(NotInStock).ToLowerInvariant());
        public static ProductState IsFaulty = new ProductState(202, nameof(IsFaulty).ToLowerInvariant());

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductState"/> class.
        /// </summary>
        protected ProductState()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductState"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        public ProductState(int id, string name)
            : base(id, name)
        {
        }

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns>IEnumerable&lt;ProductState&gt;.</returns>
        public static IEnumerable<ProductState> List() => new[] { Ok, NotInStock, IsFaulty };

        /// <summary>
        /// Froms the name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ProductState.</returns>
        public static ProductState FromName(string name)
        {
            var state = List().SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
            return state;
        }

        /// <summary>
        /// Froms the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ProductState.</returns>
        public static ProductState From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
            return state;
        }
    }
}
