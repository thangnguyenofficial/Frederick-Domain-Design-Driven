// ***********************************************************************
// Assembly         : FrederickNguyen.Infrastructure.Data
// Author           : thangnd
// Created          : 07-17-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-17-2018
// ***********************************************************************
// <copyright file="CartRepository.cs" company="FrederickNguyen.Infrastructure.Data">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using FrederickNguyen.DomainCore.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Carts.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Carts.Repository;
using Microsoft.EntityFrameworkCore;

namespace FrederickNguyen.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Class CartRepository.
    /// </summary>
    public class CartRepository : ICartRepository
    {
        /// <summary>
        /// The carts
        /// </summary>
        protected static List<Cart> Carts = new List<Cart>();

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Cart.</returns>
        public Cart FindById(Guid id)
        {
            return Carts.Find(c => c.CustomerId == id);
        }

        /// <summary>
        /// Finds the single by spec.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns>Cart.</returns>
        public Cart FindSingleBySpec(ISpecification<Cart> spec)
        {
            return Find(spec).FirstOrDefault();
        }

        /// <summary>
        /// Finds this instance.
        /// </summary>
        /// <returns>IEnumerable&lt;Cart&gt;.</returns>
        public IEnumerable<Cart> Find()
        {
            return Carts.AsEnumerable();
        }

        /// <summary>
        /// Finds the specified spec.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns>IEnumerable&lt;Cart&gt;.</returns>
        public IEnumerable<Cart> Find(ISpecification<Cart> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(Carts.AsQueryable(), (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes, (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult.Where(spec.Criteria).AsEnumerable();
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Cart.</returns>
        public Cart Add(Cart entity)
        {
            Carts.Add(entity);
            return entity;
        }

        public void Update(Cart entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Cart entity)
        {
            throw new NotImplementedException();
        }
    }
}
