// ***********************************************************************
// Assembly         : FrederickNguyen.DomainCore
// Author           : thangnd
// Created          : 07-11-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-11-2018
// ***********************************************************************
// <copyright file="IRequestCorrelationIdentifier.cs" company="FrederickNguyen.DomainCore">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace FrederickNguyen.DomainCore.Logging
{
    /// <summary>
    /// Interface IRequestCorrelationIdentifier
    /// </summary>
    public interface IRequestCorrelationIdentifier
    {
        /// <summary>
        /// Gets the correlation identifier.
        /// </summary>
        /// <value>The correlation identifier.</value>
        string CorrelationId { get; }
    }
}
