// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 05-15-2019
//
// Last Modified By : thangnd
// Last Modified On : 05-15-2019
// ***********************************************************************
// <copyright file="OrderingDomainException.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace FrederickNguyen.DomainLayer.Exceptions
{
    /// <summary>
    /// Class OrderingDomainException.
    /// </summary>
    public class CustomerDomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDomainException"/> class.
        /// </summary>
        public CustomerDomainException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDomainException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CustomerDomainException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDomainException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public CustomerDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
