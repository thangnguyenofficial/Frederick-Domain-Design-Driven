// ***********************************************************************
// Assembly         : FrederickNguyen.DomainCore
// Author           : thangnd
// Created          : 07-09-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-09-2018
// ***********************************************************************
// <copyright file="IEventHandler.cs" company="FrederickNguyen.DomainCore">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using MediatR;

namespace FrederickNguyen.DomainCore.Events
{
    /// <summary>
    /// Interface IEventHandler
    /// </summary>
    /// <typeparam name="TDomainEvent">The type of the t domain event.</typeparam>
    /// <seealso cref="MediatR.INotificationHandler{TDomainEvent}" />
    public interface IEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
        where TDomainEvent : DomainEvent
    {
    }
}
