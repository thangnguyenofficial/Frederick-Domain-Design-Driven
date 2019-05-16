// ***********************************************************************
// Assembly         : FrederickNguyen.DomainCore
// Author           : thangnd
// Created          : 06-23-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-23-2018
// ***********************************************************************
// <copyright file="MediatorHandler.cs" company="FrederickNguyen.DomainCore">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading.Tasks;
using MediatR;

namespace FrederickNguyen.DomainCore.Commands
{
    /// <summary>
    /// Class MediatorHandler. This class cannot be inherited.
    /// </summary>
    public sealed class CommandDispatcher : ICommandDispatcher
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandDispatcher"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public CommandDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Sends the specified command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> Send<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}
