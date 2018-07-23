// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-17-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-17-2018
// ***********************************************************************
// <copyright file="ICartRepository.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainCore.Repository;
using FrederickNguyen.DomainLayer.AggregatesModels.Carts.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Carts.Repository
{
    /// <summary>
    /// Interface ICartRepository
    /// </summary>
    public interface ICartRepository : IRepository<Cart>
    {
    }
}
