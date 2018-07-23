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

using FrederickNguyen.DomainCore.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrederickNguyen.Infrastructure.Data.EntityConfigurations
{
    /// <summary>
    /// Class CountryEntityTypeConfiguration.
    /// </summary>
    public class DomainEventRecordEntityTypeConfiguration : IEntityTypeConfiguration<DomainEventRecord>
    {
        /// <summary>
        /// Configures the specified country configuration.
        /// </summary>
        /// <param name="countryConfiguration">The country configuration.</param>
        public void Configure(EntityTypeBuilder<DomainEventRecord> countryConfiguration )
        {
            countryConfiguration.ToTable("DomainEventRecord");
            countryConfiguration.HasKey(b => b.CorrelationId);
        }
    }
}
