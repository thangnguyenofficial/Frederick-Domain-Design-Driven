// ***********************************************************************
// Assembly         : FrederickNguyen.Infrastructure
// Author           : thangnd
// Created          : 06-22-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-22-2018
// ***********************************************************************
// <copyright file="EfRepository.cs" company="FrederickNguyen.Infrastructure">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using FrederickNguyen.DomainCore.Models;
using FrederickNguyen.DomainCore.Repository;
using FrederickNguyen.DomainCore.Specification;
using FrederickNguyen.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FrederickNguyen.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Class EfRepository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfRepository<T> : IRepository<T> where T : Entity 
    {
        /// <summary>
        /// The database context
        /// </summary>
        protected readonly FrederickContext FrederickContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public EfRepository(FrederickContext dbContext)
        {
            FrederickContext = dbContext;
        }

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public T FindById(Guid id)
        {
            return FrederickContext.Set<T>().Find(id);
        }

        /// <summary>
        /// Finds the single by spec.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns>T.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public T FindSingleBySpec(ISpecification<T> spec)
        {
            return Find(spec).FirstOrDefault();
        }

        /// <summary>
        /// Finds this instance.
        /// </summary>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public IEnumerable<T> Find()
        {
            return FrederickContext.Set<T>().AsEnumerable();
        }

        /// <summary>
        /// Finds the specified spec.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public IEnumerable<T> Find(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(FrederickContext.Set<T>().AsQueryable(), (current, include) => current.Include(include));

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
        /// <returns>T.</returns>
        public T Add(T entity)
        {
            return FrederickContext.Set<T>().Add(entity).Entity;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(T entity)
        {
            //FrederickContext.Set<T>().Update(entity);
            FrederickContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(T entity)
        {
            FrederickContext.Set<T>().Remove(entity);
        }
    }
}
