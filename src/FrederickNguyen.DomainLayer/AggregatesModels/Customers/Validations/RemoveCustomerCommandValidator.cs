// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 06-22-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-22-2018
// ***********************************************************************
// <copyright file="CreateCustomerCommandValidator.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FluentValidation;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Commands;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Validations
{
    /// <summary>
    /// Class RemoveCustomerCommandValidator.
    /// </summary>
    public class RemoveCustomerCommandValidator : AbstractValidator<RemoveCustomerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerCommandValidator" /> class.
        /// </summary>
        public RemoveCustomerCommandValidator()
        {
            RuleFor(customer => customer.Id).NotEmpty().WithMessage("Customer id is required");
        }
    }
}
