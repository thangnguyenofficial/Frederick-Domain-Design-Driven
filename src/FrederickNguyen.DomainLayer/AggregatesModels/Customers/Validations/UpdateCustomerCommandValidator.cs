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

using System;
using System.Text.RegularExpressions;
using FluentValidation;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Commands;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Validations
{
    /// <summary>
    /// Class UpdateCustomerCommandValidator.
    /// </summary>
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerCommandValidator" /> class.
        /// </summary>
        public UpdateCustomerCommandValidator()
        {
            RuleFor(customer => customer.Id).NotEmpty().WithMessage("Customer id is required");
            RuleFor(customer => customer.FirstName).NotEmpty().WithMessage("The first name is required");
            RuleFor(customer => customer.LastName).NotEmpty().WithMessage("The last name is required");
            RuleFor(customer => customer.CountryId).NotEmpty().WithMessage("The country is required");
        }
    }
}
