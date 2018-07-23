// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 06-20-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-20-2018
// ***********************************************************************
// <copyright file="ICustomerRepository.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainCore.Repository;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Products.Repository
{
    /// <summary>
    /// Interface ICustomerRepository
    /// </summary>
    public interface IProductRepository : IRepository<Product>
    {
    }
}
