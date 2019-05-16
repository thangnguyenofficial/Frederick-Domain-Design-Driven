// ***********************************************************************
// Assembly         : FrederickNguyen.DomainCore
// Author           : thangnd
// Created          : 06-18-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-18-2018
// ***********************************************************************
// <copyright file="Entity.cs" company="FrederickNguyen.DomainCore">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using FrederickNguyen.DomainCore.Events;
using MediatR;

namespace FrederickNguyen.DomainCore.Models
{
    /// <summary>
    /// Class Entity.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        /// <summary>
        /// Determines whether this instance is transient.
        /// </summary>
        /// <returns><c>true</c> if this instance is transient; otherwise, <c>false</c>.</returns>
        public bool IsTransient()
        {
            return Id == Guid.Empty;
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }

        /// <summary>
        /// The domain events
        /// </summary>
        private List<DomainEvent> _domainEvents;

        /// <summary>
        /// Gets the domain events.
        /// </summary>
        /// <value>The domain events.</value>
        public List<DomainEvent> DomainEvents => _domainEvents;

        /// <summary>
        /// Adds the domain event.
        /// </summary>
        /// <param name="eventItem">The event item.</param>
        public void AddDomainEvent(DomainEvent eventItem)
        {
            _domainEvents = _domainEvents ?? new List<DomainEvent>();
            _domainEvents.Add(eventItem);
        }

        /// <summary>
        /// Removes the domain event.
        /// </summary>
        /// <param name="eventItem">The event item.</param>
        public void RemoveDomainEvent(DomainEvent eventItem)
        {
            if (DomainEvents is null) return;
            DomainEvents.Remove(eventItem);
        }
    }
}
