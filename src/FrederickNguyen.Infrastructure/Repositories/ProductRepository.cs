// ***********************************************************************
// Assembly         : FrederickNguyen.Infrastructure.Data
// Author           : thangnd
// Created          : 07-12-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-12-2018
// ***********************************************************************
// <copyright file="ProductRepository.cs" company="FrederickNguyen.Infrastructure.Data">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainLayer.AggregatesModels.Products.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Repository;
using FrederickNguyen.Infrastructure.Data.Context;

namespace FrederickNguyen.Infrastructure.Data.Repositories
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ProductRepository(FrederickContext dbContext)
            : base(dbContext)
        {
        }
    }
}
