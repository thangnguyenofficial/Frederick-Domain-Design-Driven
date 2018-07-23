// ***********************************************************************
// Assembly         : FrederickNguyen.Infrastructure.CrossCutting.IoC
// Author           : thangnd
// Created          : 07-09-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-09-2018
// ***********************************************************************
// <copyright file="NativeInjectorBootStrapper.cs" company="FrederickNguyen.Infrastructure.CrossCutting.IoC">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.Extensions.DependencyInjection;

namespace FrederickNguyen.Infrastructure.CrossCutting.IoC
{
    /// <summary>
    /// Class NativeInjectorBootStrapper.
    /// </summary>
    public class NativeInjectorBootStrapper
    {
        /// <summary>
        /// Registers the specified services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void Register(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            ApplicationLayerInjector.Register(services);
            DomainLayerInjector.Register(services);
            InfrastructureLayerInjector.Register(services);
        }
    }
}
