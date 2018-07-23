// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-06-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="UpdateCustomerCommand.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Validations;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Commands
{
    /// <summary>
    /// Class UpdateCustomerCommand.
    /// </summary>
    public class UpdateCustomerCommand : CustomerCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCustomerCommand" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="countryId">The country identifier.</param>
        public UpdateCustomerCommand(Guid id, string firstName, string lastName, Guid countryId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CountryId = countryId;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
