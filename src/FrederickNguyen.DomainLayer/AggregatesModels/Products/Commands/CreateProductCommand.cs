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

using FrederickNguyen.DomainLayer.AggregatesModels.Products.Validations;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Products.Commands
{
    /// <summary>
    /// Class CreateCustomerCommand.
    /// </summary>
    public sealed class CreateProductCommand : ProductCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductCommand" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="code">The code.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="cost">The cost.</param>
        public CreateProductCommand(string name, string code, int quantity, decimal cost)
        {
            Name = name;
            Quantity = quantity;
            Cost = cost;
            Code = code;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
        public override bool IsValid()
        {
            ValidationResult = new CreateProductCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
