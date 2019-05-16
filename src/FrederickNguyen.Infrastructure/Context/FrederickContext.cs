// ***********************************************************************
// Assembly         : FrederickNguyen.Infrastructure
// Author           : thangnd
// Created          : 06-20-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-20-2018
// ***********************************************************************
// <copyright file="FrederickContext.cs" company="FrederickNguyen.Infrastructure">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Purchases.Models;
using FrederickNguyen.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FrederickNguyen.Infrastructure.Data.Context
{
    /// <summary>
    /// Class FrederickContext.
    /// </summary>
    public class FrederickContext : DbContext
    {
        #region  DbSet

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>The customers.</value>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the purchase.
        /// </summary>
        /// <value>The purchase.</value>
        public DbSet<Purchase> Purchases { get; set; }

        /// <summary>
        /// Gets or sets the purchased products.
        /// </summary>
        /// <value>The purchased products.</value>
        public DbSet<PurchasedProduct> PurchasedProducts { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrederickContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public FrederickContext(DbContextOptions<FrederickContext> options) : base(options)
        {
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.</remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //model builder
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PurchasedProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CreditCardEntityTypeConfiguration());
        }

        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// The base implementation does nothing.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
