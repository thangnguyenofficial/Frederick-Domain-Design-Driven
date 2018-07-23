// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 06-15-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-15-2018
// ***********************************************************************
// <copyright file="Country.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using FrederickNguyen.DomainCore.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Countries
{
    /// <summary>
    /// Class Country.
    /// </summary>
    public class Country : Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; protected set; }

        /// <summary>
        /// Creates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Country.</returns>
        public static Country Create(string name)
        {
            return Create(Guid.NewGuid(), name);
        }

        /// <summary>
        /// Creates the specified country identifier.
        /// </summary>
        /// <param name="countryId">The country identifier.</param>
        /// <param name="name">The name.</param>
        /// <returns>Country.</returns>
        public static Country Create(Guid countryId, string name)
        {
            var country = new Country()
            {
                Id = countryId,
                Name = name
            };
            return country;
        }
    }
}
