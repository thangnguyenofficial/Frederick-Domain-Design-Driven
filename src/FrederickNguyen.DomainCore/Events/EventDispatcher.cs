// ***********************************************************************
// Assembly         : FrederickNguyen.DomainCore
// Author           : thangnd
// Created          : 07-09-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-09-2018
// ***********************************************************************
// <copyright file="EventDispatcher.cs" company="FrederickNguyen.DomainCore">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System.Threading.Tasks;
using MediatR;

namespace FrederickNguyen.DomainCore.Events
{
    /// <summary>
    /// Class EventDispatcher.
    /// </summary>
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventDispatcher"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public EventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Raises the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event">The event.</param>
        /// <returns>Task.</returns>
        public Task RaiseEvent<T>(T @event) where T : DomainEvent
        {
            return _mediator.Publish(@event);
        }
    }
}
