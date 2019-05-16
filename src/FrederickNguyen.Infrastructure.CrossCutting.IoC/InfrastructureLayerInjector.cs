// ***********************************************************************
// Assembly         : FrederickNguyen.Api
// Author           : thangnd
// Created          : 06-21-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-21-2018
// ***********************************************************************
// <copyright file="InfrastructureLayerInjector.cs" company="FrederickNguyen.Api">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainCore.Repository;
using FrederickNguyen.DomainCore.UnitOfWork;
using FrederickNguyen.DomainLayer.AggregatesModels.Carts.Repository;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Repository;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Repository;
using FrederickNguyen.Infrastructure.Components.Mail;
using FrederickNguyen.Infrastructure.Data.Context;
using FrederickNguyen.Infrastructure.Data.Repositories;
using FrederickNguyen.Infrastructure.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace FrederickNguyen.Infrastructure.CrossCutting.IoC
{
    /// <summary>
    /// Class InfrastructureLayerInjector.
    /// </summary>
    public class InfrastructureLayerInjector
    {
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void Register(IServiceCollection services)
        {
            // Infra - Data
            services.AddDbContext<FrederickContext>();
            services.AddDbContext<EventStoreContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Infra - repository
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();

            //Infra  - services
            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}