// ***********************************************************************
// Assembly         : FrederickNguyen.DomainCore
// Author           : thangnd
// Created          : 07-03-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-03-2018
// ***********************************************************************
// <copyright file="DomainNotificationHandler.cs" company="FrederickNguyen.DomainCore">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using FrederickNguyen.DomainCore.Events;

namespace FrederickNguyen.DomainCore.Notification
{
    /// <summary>
    /// Class DomainNotificationHandler.
    /// </summary>
    public class DomainNotificationHandler : IEventHandler<DomainNotification>
    {
        /// <summary>
        /// The notifications
        /// </summary>
        private List<DomainNotification> _notifications;

        /// <summary>
        /// Gets the notifications.
        /// </summary>
        /// <value>The notifications.</value>
        public ReadOnlyCollection<DomainNotification> Notifications => _notifications.AsReadOnly();

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainNotificationHandler"/> class.
        /// </summary>
        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Determines whether this instance has notifications.
        /// </summary>
        /// <returns><c>true</c> if this instance has notifications; otherwise, <c>false</c>.</returns>
        public virtual bool HasNotifications()
        {
            return Notifications.Count <= 0;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}
