// ***********************************************************************
// Assembly         : FrederickNguyen.DomainCore
// Author           : thangnd
// Created          : 06-22-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-22-2018
// ***********************************************************************
// <copyright file="CommandBase.cs" company="FrederickNguyen.DomainCore">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FluentValidation.Results;
using MediatR;
using Newtonsoft.Json;

namespace FrederickNguyen.DomainCore.Commands
{
    /// <summary>
    /// Class Command.
    /// </summary>
    public abstract class Command : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>The type of the message.</value>
        [JsonIgnore]
        public string MessageType { get; set; }

        /// <summary>
        /// Gets or sets the validation result.
        /// </summary>
        /// <value>The validation result.</value>
        public ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
        public abstract bool IsValid();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        protected Command()
        {
            MessageType = GetType().Name;
        }
    }
}
