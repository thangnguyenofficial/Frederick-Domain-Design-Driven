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
    /// Class RemoveCustomerCommand.
    /// </summary>
    public class RemoveCustomerCommand : CustomerCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveCustomerCommand"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public RemoveCustomerCommand(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool IsValid()
        {
            ValidationResult = new RemoveCustomerCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
