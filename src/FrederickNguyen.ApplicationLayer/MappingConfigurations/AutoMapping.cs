// ***********************************************************************
// Assembly         : FrederickNguyen.ApplicationLayer
// Author           : thangnd
// Created          : 06-23-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-23-2018
// ***********************************************************************
// <copyright file="AutoMapping.cs" company="FrederickNguyen.ApplicationLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper;

namespace FrederickNguyen.ApplicationLayer.MappingConfigurations
{
    /// <summary>
    /// Class AutoMapping.
    /// </summary>
    public class AutoMapping
    {
        /// <summary>
        /// Registers the mappings.
        /// </summary>
        /// <returns>MapperConfiguration.</returns>
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingEntityToDtoProfile());
                cfg.AddProfile(new MappingViewModelToCommandProfile());
            });
        }
    }
}
