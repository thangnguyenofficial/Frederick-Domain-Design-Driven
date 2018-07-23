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

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.EventHandlers
{
    /// <summary>
    /// Class CustomerCheckOutEventHandler.
    /// </summary>
    public class CustomerCheckOutEventHandler : IEventHandler<CustomerCheckOutEvent>
    {
        private readonly IEmailSender _emailSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCheckOutEventHandler"/> class.
        /// </summary>
        /// <param name="emailSender">The email sender.</param>
        public CustomerCheckOutEventHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public Task Handle(CustomerCheckOutEvent notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            _emailSender.SendEmailConfirmationAsync("", "");
            return Task.CompletedTask;
        }
    }
}