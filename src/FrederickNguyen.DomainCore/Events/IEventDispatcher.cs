// ***********************************************************************
// Assembly         : FrederickNguyen.DomainCore
// Author           : thangnd
// Created          : 07-09-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-09-2018
// ***********************************************************************
// <copyright file="IEventDispatcher.cs" company="FrederickNguyen.DomainCore">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading.Tasks;

namespace FrederickNguyen.DomainCore.Events
{
    /// <summary>
    /// Interface IEventDispatcher
    /// </summary>
    public interface IEventDispatcher
    {
        /// <summary>
        /// Raises the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event">The event.</param>
        /// <returns>Task.</returns>
        Task RaiseEvent<T>(T @event) where T : DomainEvent;
    }
}
