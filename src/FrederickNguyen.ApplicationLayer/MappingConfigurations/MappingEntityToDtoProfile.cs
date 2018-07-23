// ***********************************************************************
// Assembly         : FrederickNguyen.ApplicationLayer
// Author           : thangnd
// Created          : 07-09-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-09-2018
// ***********************************************************************
// <copyright file="MappingEntityToDto.cs" company="FrederickNguyen.ApplicationLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper;
using FrederickNguyen.ApplicationLayer.DataTransferObjects;
using FrederickNguyen.DomainLayer.AggregatesModels.Carts.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Purchases.Models;

namespace FrederickNguyen.ApplicationLayer.MappingConfigurations
{
    /// <summary>
    /// Class MappingEntityToDto.
    /// </summary>
    public class MappingEntityToDtoProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingEntityToDtoProfile" /> class.
        /// </summary>
        public MappingEntityToDtoProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Cart, CartDto>();
            CreateMap<CartProduct, CartProductDto>();
            CreateMap<Purchase, CheckOutResultDto>()
                .ForMember(x => x.PurchaseId, options => options.MapFrom(x => x.Id));
        }
    }
}
