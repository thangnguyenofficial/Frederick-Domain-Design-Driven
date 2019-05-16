// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-06-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="CustomerCommand.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using FrederickNguyen.DomainCore.Commands;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Commands
{
    /// <summary>
    /// Class CustomerCommand.
    /// </summary>
    public abstract class CustomerCommand : Command
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
    }
}
