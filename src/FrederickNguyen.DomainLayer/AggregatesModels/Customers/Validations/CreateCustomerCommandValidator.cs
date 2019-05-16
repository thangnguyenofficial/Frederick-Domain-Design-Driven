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

using System.Text.RegularExpressions;
using FluentValidation;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Commands;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Customers.Validations
{
    /// <summary>
    /// Class CreateCustomerCommandValidator.
    /// </summary>
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerCommandValidator" /> class.
        /// </summary>
        public CreateCustomerCommandValidator()
        {
            RuleFor(customer => customer.FirstName).NotEmpty().WithMessage("The first name is required");
            RuleFor(customer => customer.LastName).NotEmpty().WithMessage("The last name is required");

            RuleFor(customer => customer.Email).NotEmpty().WithMessage("The email is required");
            RuleFor(customer => customer.Email).EmailAddress().WithMessage("Invalid Email Address");

            RuleFor(customer => customer.Password).NotEmpty().WithMessage("The password is required");
            RuleFor(customer => customer.Password).Must(ValidatePassword).WithMessage("password must be of minimum 8 characters length, includes number, " +
                                                                                      "upper char and lower char");
        }

        /// <summary>
        /// Validates the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool ValidatePassword(string password)
        {
            var input = password;

            var hasNumber = new Regex(@"[0-9]+");
            //var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,100}");
            var hasLowerChar = new Regex(@"[a-z]+");
            //var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input)) return false;
            //if (!hasUpperChar.IsMatch(input)) return false;
            if (!hasMiniMaxChars.IsMatch(input)) return false;
            if (!hasNumber.IsMatch(input)) return false;
            //if (!hasSymbols.IsMatch(input)) return false;
            return true;
        }
    }
}
