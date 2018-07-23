// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-19-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-19-2018
// ***********************************************************************
// <copyright file="PaymentStatus.cs" company="FrederickNguyen.DomainLayer">
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
    /// Class PaymentStatus.
    /// </summary>
    public class PaymentStatus : Enumeration
    {
        public static PaymentStatus Ok = new PaymentStatus(100, nameof(Ok).ToLowerInvariant());
        public static PaymentStatus UnpaidBalance = new PaymentStatus(101, nameof(UnpaidBalance).ToLowerInvariant());

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentStatus"/> class.
        /// </summary>
        protected PaymentStatus()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentStatus"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        public PaymentStatus(int id, string name)
            : base(id, name)
        {
        }

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns>IEnumerable&lt;PaymentStatus&gt;.</returns>
        public static IEnumerable<PaymentStatus> List() => new[] { Ok, UnpaidBalance };

        /// <summary>
        /// Froms the name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>PaymentStatus.</returns>
        public static PaymentStatus FromName(string name)
        {
            var state = List().SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
            return state;
        }

        /// <summary>
        /// Froms the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>PaymentStatus.</returns>
        public static PaymentStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
            return state;
        }
    }
}
