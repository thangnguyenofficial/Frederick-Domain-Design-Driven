// ***********************************************************************
// Assembly         : FrederickNguyen.Api
// Author           : thangnd
// Created          : 06-21-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-21-2018
// ***********************************************************************
// <copyright file="Startup.cs" company="FrederickNguyen.Api">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper;
using FrederickNguyen.DomainCore.Commands;
using FrederickNguyen.DomainCore.Notification;
using FrederickNguyen.DomainCore.Repository;
using FrederickNguyen.Infrastructure.CrossCutting.IoC;
using FrederickNguyen.Infrastructure.Data.Repositories;
using FrederickNguyen.WebApi.Infrastructure.Behaviors;
using FrederickNguyen.WebApi.Infrastructure.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace FrederickNguyen.WebApi
{
    /// <summary>
    /// Class Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).AddControllersAsServices();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "DDD Sample HTTP API",
                    Version = "v1",
                    Description = "The Sameple Service HTTP API",
                    TermsOfService = "Terms Of Service"
                });
            });

            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper();

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var pathBase = Configuration["PATH_BASE"];
            if (!string.IsNullOrEmpty(pathBase))
            {
                app.UsePathBase(pathBase);
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "DDD Sample.API V1");
               });
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.Register(services);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        }
    }
}
