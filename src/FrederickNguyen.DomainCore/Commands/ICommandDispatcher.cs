// ***********************************************************************
// Assembly         : FrederickNguyen.DomainCore
// Author           : thangnd
// Created          : 06-22-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-22-2018
// ***********************************************************************
// <copyright file="IMediatorHandler.cs" company="FrederickNguyen.DomainCore">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading.Tasks;

namespace FrederickNguyen.DomainCore.Commands
{
    /// <summary>
    /// Interface IMediatorHandler
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Sends the specified command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        Task<bool> Send<T>(T command) where T : Command;
    }
}
