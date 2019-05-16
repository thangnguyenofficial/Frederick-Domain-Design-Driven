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
    /// Class CountryEntityTypeConfiguration.
    /// </summary>
    public class CreditCardEntityTypeConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        /// <summary>
        /// Configures the specified customer configuration.
        /// </summary>
        /// <param name="creditcardEntityTypeBuilder">The creditcard entity type builder.</param>
        public void Configure(EntityTypeBuilder<CreditCard> creditcardEntityTypeBuilder )
        {
            creditcardEntityTypeBuilder.ToTable("CreditCard");
            creditcardEntityTypeBuilder.HasKey(b => b.Id);
            creditcardEntityTypeBuilder.Ignore(b => b.DomainEvents);
        }
    }
}
