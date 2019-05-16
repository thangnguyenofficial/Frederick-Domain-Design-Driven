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

using FrederickNguyen.DomainLayer.AggregatesModels.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrederickNguyen.Infrastructure.Data.EntityConfigurations
{
    /// <summary>
    /// Class ProductEntityTypeConfiguration.
    /// </summary>
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        /// Configures the specified product configuration.
        /// </summary>
        /// <param name="productConfiguration">The product configuration.</param>
        public void Configure(EntityTypeBuilder<Product> productConfiguration)
        {
            productConfiguration.ToTable("Product");
            productConfiguration.Ignore(b => b.DomainEvents);
            productConfiguration.HasKey(b => b.Id);
            productConfiguration.Property(b => b.Cost).HasColumnType("money");
        }
    }
}
