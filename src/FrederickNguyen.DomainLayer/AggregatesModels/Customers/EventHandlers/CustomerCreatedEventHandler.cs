// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-05-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-05-2018
// ***********************************************************************
// <copyright file="CustomerCreatedEvents.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading;
using System.Threading.Tasks;
using FrederickNguyen.DomainCore.Events;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Events;
using FrederickNguyen.Infrastructure.Components.Mail;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.EventHandlers
{
    /// <summary>
    /// Class CustomerCheckOutEventHandler.
    /// </summary>
    public class CustomerCreatedEventHandler : IEventHandler<CustomerCreatedEvent>
    {
        private readonly IEmailSender _emailSender;
        private readonly ILoggerFactory _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCreatedEventHandler" /> class.
        /// </summary>
        /// <param name="emailSender">The email sender.</param>
        /// <param name="logger">The logger.</param>
        public CustomerCreatedEventHandler(IEmailSender emailSender, ILoggerFactory logger)
        {
            _emailSender = emailSender;
            _logger = logger;
        }

        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            _emailSender.SendEmailConfirmationAsync("", "");
            _logger.CreateLogger(nameof(CustomerCreatedEventHandler)).LogTrace($"Customer with Email: {notification.Customer.Email} has been successfully created");
            return Task.CompletedTask;
        }
    }
}