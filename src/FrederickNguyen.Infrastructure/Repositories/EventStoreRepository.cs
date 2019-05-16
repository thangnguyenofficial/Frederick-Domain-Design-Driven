// ***********************************************************************
// Assembly         : FrederickNguyen.Infrastructure.Data
// Author           : thangnd
// Created          : 07-11-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-11-2018
// ***********************************************************************
// <copyright file="EventStoreRepository.cs" company="FrederickNguyen.Infrastructure.Data">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FrederickNguyen.DomainCore.Events;
using FrederickNguyen.DomainCore.EventSourcing;
using FrederickNguyen.DomainCore.Repository;
using FrederickNguyen.Infrastructure.Data.Context;

namespace FrederickNguyen.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Class EventStoreRepository.
    /// </summary>
    public class EventStoreRepository : IEventStoreRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly EventStoreContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStoreRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EventStoreRepository(EventStoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the specified domain event.
        /// </summary>
        /// <typeparam name="TDomainEvent">The type of the t domain event.</typeparam>
        /// <param name="domainEvent">The domain event.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Add<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent
        {
            _context.EventStoreRecords.Add(new EventStoreRecord
            {
                Created = domainEvent.Created,
                Type = domainEvent.Type,
                Content = domainEvent.Content,
                CorrelationId = domainEvent.CorrelationId
            });
            _context.SaveChanges();
        }
    }
}
