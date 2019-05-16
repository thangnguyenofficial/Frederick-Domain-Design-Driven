// ***********************************************************************
// Assembly         : FrederickNguyen.ApplicationLayer
// Author           : thangnd
// Created          : 06-23-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-23-2018
// ***********************************************************************
// <copyright file="MappingViewModelToCommandProfile.cs" company="FrederickNguyen.ApplicationLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper;
using FrederickNguyen.ApplicationLayer.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Commands;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Commands;

namespace FrederickNguyen.ApplicationLayer.MappingConfigurations
{
    /// <summary>
    /// Class MappingViewModelToCommandProfile.
    /// </summary>
    public class MappingViewModelToCommandProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingViewModelToCommandProfile"/> class.
        /// </summary>
        public MappingViewModelToCommandProfile()
        {
            CreateMap<AddNewCustomerViewModel, CreateCustomerCommand>()
                .ConstructUsing(c => new CreateCustomerCommand(c.FirstName, c.LastName, c.Email, c.Password, c.CountryId));
            CreateMap<RemoveCustomerViewModel, RemoveCustomerCommand>()
               .ConstructUsing(c => new RemoveCustomerCommand(c.CustomerId));
            CreateMap<AddNewProductViewModel, CreateProductCommand>()
               .ConstructUsing(c => new CreateProductCommand(c.Name, c.Code, c.Quantity, c.Cost));
        }
    }
}
