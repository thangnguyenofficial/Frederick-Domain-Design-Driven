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

using AutoMapper;
using FrederickNguyen.ApplicationLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FrederickNguyen.Infrastructure.CrossCutting.IoC
{
    /// <summary>
    /// Class ApplicationLayerInjector.
    /// </summary>
    public class ApplicationLayerInjector
    {
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void Register(IServiceCollection services)
        {
            //Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
        }
    }
}