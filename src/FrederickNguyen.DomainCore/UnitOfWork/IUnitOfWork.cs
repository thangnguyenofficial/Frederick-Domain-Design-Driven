// ***********************************************************************
// Assembly         : FrederickNguyen.DomainCore
// Author           : thangnd
// Created          : 06-20-2018
//
// Last Modified By : thangnd
// Last Modified On : 03-08-2018
// ***********************************************************************
// <copyright file="IUnitOfWork.cs" company="FrederickNguyen.DomainCore">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading;
using System.Threading.Tasks;

namespace FrederickNguyen.DomainCore.UnitOfWork
{
    /// <summary>
    /// Interface IUnitOfWork
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits this instance.
        /// </summary>
        int Commit();

        /// <summary>
        /// Commits the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
        
        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        void Rollback();
    }
}
