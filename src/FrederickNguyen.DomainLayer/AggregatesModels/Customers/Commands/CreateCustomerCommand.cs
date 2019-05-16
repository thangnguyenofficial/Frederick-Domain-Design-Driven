// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 06-22-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-22-2018
// ***********************************************************************
// <copyright file="CreateCustomer.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Validations;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Commands
{
    /// <summary>
    /// Class CreateCustomerCommand.
    /// </summary>
    public sealed class CreateCustomerCommand : CustomerCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerCommand" /> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="countryId">The country identifier.</param>
        public CreateCustomerCommand(string firstName, string lastName, string email, string password, Guid countryId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
        public override bool IsValid()
        {
            ValidationResult = new CreateCustomerCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
