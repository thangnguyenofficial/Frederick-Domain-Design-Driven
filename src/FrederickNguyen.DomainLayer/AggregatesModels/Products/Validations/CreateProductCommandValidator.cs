// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-14-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-14-2018
// ***********************************************************************
// <copyright file="CreateProductCommandValidator.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FluentValidation;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Commands;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Products.Validations
{
    /// <summary>
    /// Class CreateProductCommandValidator.
    /// </summary>
    public class CreateProductCommandValidator :  AbstractValidator<CreateProductCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductCommandValidator"/> class.
        /// </summary>
        public CreateProductCommandValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("The product name is required");
            RuleFor(product => product.Code).NotEmpty().WithMessage("The product code is required");
        }
    }
}
