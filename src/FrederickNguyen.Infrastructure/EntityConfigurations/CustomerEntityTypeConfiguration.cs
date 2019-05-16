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

using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrederickNguyen.Infrastructure.Data.EntityConfigurations
{
    /// <summary>
    /// Class CustomerEntityTypeConfiguration.
    /// </summary>
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// Configures the specified customer configuration.
        /// </summary>
        /// <param name="customerConfiguration">The customer configuration.</param>
        public void Configure(EntityTypeBuilder<Customer> customerConfiguration )
        {
            customerConfiguration.ToTable("Customer");
            customerConfiguration.HasKey(c => c.Id);
            customerConfiguration.Property(b => b.Balance).HasColumnType("money");
            customerConfiguration.Ignore(b => b.DomainEvents);
            
            customerConfiguration.HasMany(b => b.CreditCards)
               .WithOne()
               .HasForeignKey("CustomerId")
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
