// ***********************************************************************
// Assembly         : FrederickNguyen.Infrastructure.Data
// Author           : thangnd
// Created          : 05-15-2019
//
// Last Modified By : thangnd
// Last Modified On : 05-15-2019
// ***********************************************************************
// <copyright file="MediatorExtension.cs" company="FrederickNguyen.Infrastructure.Data">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using System.Threading.Tasks;
using FrederickNguyen.DomainCore.Models;
using FrederickNguyen.Infrastructure.Data.Context;
using MediatR;

namespace FrederickNguyen.Infrastructure.Data.Extensions
{
    /// <summary>
    /// Class MediatorExtension.
    /// </summary>
    static class MediatorExtension
    {
        /// <summary>
        /// dispatch domain events as an asynchronous operation.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="ctx">The CTX.</param>
        /// <returns>Task.</returns>
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, FrederickContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                  .Entries<Entity>()
                  .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities.SelectMany(x => x.Entity.DomainEvents).ToList();
            domainEntities.ToList().ForEach(entity => entity.Entity.DomainEvents.Clear());

            var tasks = domainEvents.Select(async (domainEvent) =>
                {
                    await mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
