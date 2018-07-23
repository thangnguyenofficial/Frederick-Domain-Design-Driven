// ***********************************************************************
// Assembly         : FrederickNguyen.DomainCore
// Author           : thangnd
// Created          : 06-22-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-22-2018
// ***********************************************************************
// <copyright file="DomainEvent.cs" company="FrederickNguyen.DomainCore">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;

namespace FrederickNguyen.DomainCore.Events
{
    /// <summary>
    /// Class DomainEvent.
    /// </summary>
    /// <seealso cref="MediatR.INotification" />
    public abstract class DomainEvent : INotification
    {
        /// <summary>
        /// Gets the created.
        /// </summary>
        /// <value>The created.</value>
        [JsonIgnore]
        public DateTime Created { get; private set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonIgnore]
        public string Type { get; set; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public Dictionary<string, object> Args { get; private set; }

        /// <summary>
        /// Gets or sets the correlation identifier.
        /// </summary>
        /// <value>The correlation identifier.</value>
        public Guid CorrelationId { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEvent"/> class.
        /// </summary>
        protected DomainEvent()
        {
            Created = DateTime.Now;
            Args = new Dictionary<string, object>();
            Type = GetType().Name;
        }

        /// <summary>
        /// Flattens this instance.
        /// </summary>
        public abstract void Flatten();
    }
}
