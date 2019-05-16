// ***********************************************************************
// Assembly         : FrederickNguyen.DomainCore
// Author           : thangnd
// Created          : 07-10-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-10-2018
// ***********************************************************************
// <copyright file="DomainEventHandler.cs" company="FrederickNguyen.DomainCore">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading;
using System.Threading.Tasks;
using FrederickNguyen.DomainCore.Events;
using FrederickNguyen.DomainCore.Repository;
using Newtonsoft.Json;

namespace FrederickNguyen.DomainCore.EventSourcing
{
    /// <summary>
    /// Class DomainEventHandler.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventStoreHandler<T> : IEventHandler<T> where T : DomainEvent
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStoreHandler{T}" /> class.
        /// </summary>
        /// <param name="eventStoreRepository">The domain event repository.</param>
        public EventStoreHandler(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public Task Handle(T @event, CancellationToken cancellationToken)
        {
            @event.Flatten();
            @event.CorrelationId = Guid.NewGuid();
            @event.Content = JsonConvert.SerializeObject(@event.Args);

            _eventStoreRepository.Add(@event);

            return Task.CompletedTask;
        }
    }
}
