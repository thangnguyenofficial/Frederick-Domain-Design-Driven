// ***********************************************************************
// Assembly         : FrederickNguyen.WebApi
// Author           : thangnd
// Created          : 06-23-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-23-2018
// ***********************************************************************
// <copyright file="DomainLayerInjector.cs" company="FrederickNguyen.WebApi">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainCore.Commands;
using FrederickNguyen.DomainCore.Events;
using FrederickNguyen.DomainCore.Notification;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.CommandHandlers;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Commands;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.EventHandlers;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Events;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.CommandHandlers;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Commands;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Events;
using FrederickNguyen.DomainLayer.Services.Checkout;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FrederickNguyen.Infrastructure.CrossCutting.IoC
{
    /// <summary>
    /// Class DomainLayerInjector.
    /// </summary>
    public class DomainLayerInjector
    {
        /// <summary>
        /// Registers the specified services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void Register(IServiceCollection services)
        {
            //Distributed Interface Install
    
            // Domain Bus (Mediator)
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IEventDispatcher, EventDispatcher>();
            services.AddScoped<IEventDispatcher, EventDispatcher>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerCreatedEvent>, DomainEventHandler<CustomerCreatedEvent>>();
            services.AddScoped<INotificationHandler<CustomerCreatedEvent>, CustomerCreatedEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, DomainEventHandler<CustomerUpdatedEvent>>();
            services.AddScoped<INotificationHandler<ProductCreatedEvent>, DomainEventHandler<ProductCreatedEvent>>();
            services.AddScoped<INotificationHandler<CustomerCheckOutEvent>, CustomerCheckOutEventHandler>();
            services.AddScoped<INotificationHandler<CustomerCheckOutEvent>, DomainEventHandler<CustomerCheckOutEvent>>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<CreateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<CreateProductCommand>, ProductCommandHandler>();

            // Domain - Services
            services.AddTransient<CheckoutService>();
        }
    }
}