// ***********************************************************************
// Assembly         : FrederickNguyen.Infrastructure
// Author           : thangnd
// Created          : 06-20-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-20-2018
// ***********************************************************************
// <copyright file="CustomerEntityTypeConfiguration.cs" company="FrederickNguyen.Infrastructure">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainLayer.AggregatesModels.Purchases.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrederickNguyen.Infrastructure.Data.EntityConfigurations
{
    /// <summary>
    /// Class PurchasedProductEntityTypeConfiguration.
    /// </summary>
    public class PurchasedProductEntityTypeConfiguration : IEntityTypeConfiguration<PurchasedProduct>
    {
        /// <summary>
        /// Configures the specified purchase configuration.
        /// </summary>
        /// <param name="purchaseConfiguration">The purchase configuration.</param>
        public void Configure(EntityTypeBuilder<PurchasedProduct> purchaseConfiguration)
        {
            purchaseConfiguration.ToTable("PurchasedProduct");
            purchaseConfiguration.Ignore(b => b.DomainEvents);
        
            purchaseConfiguration.HasKey(b => b.Id);
        }
    }
}
