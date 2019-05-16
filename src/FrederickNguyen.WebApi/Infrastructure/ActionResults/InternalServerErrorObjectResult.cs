// ***********************************************************************
// Assembly         : FrederickNguyen.WebApi
// Author           : thangnd
// Created          : 05-15-2019
//
// Last Modified By : thangnd
// Last Modified On : 05-15-2019
// ***********************************************************************
// <copyright file="InternalServerErrorObjectResult.cs" company="FrederickNguyen.WebApi">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrederickNguyen.WebApi.Infrastructure.ActionResults
{
    /// <summary>
    /// Class InternalServerErrorObjectResult.
    /// </summary>
    public class InternalServerErrorObjectResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorObjectResult"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public InternalServerErrorObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
