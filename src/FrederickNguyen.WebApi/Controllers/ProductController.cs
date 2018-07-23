// ***********************************************************************
// Assembly         : FrederickNguyen.WebApi
// Author           : thangnd
// Created          : 07-12-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-12-2018
// ***********************************************************************
// <copyright file="ProductController.cs" company="FrederickNguyen.WebApi">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using FrederickNguyen.ApplicationLayer.Models;
using FrederickNguyen.ApplicationLayer.Services;
using FrederickNguyen.DomainCore.Commands;
using FrederickNguyen.DomainCore.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace FrederickNguyen.WebApi.Controllers
{
    /// <summary>
    /// Class ProductController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        /// <param name="notificationHandler">The notification handler.</param>
        /// <param name="commandBusHandler">The command bus handler.</param>
        public ProductController(IProductService productService, INotificationHandler<DomainNotification> notificationHandler,
            ICommandDispatcher commandBusHandler) : base(notificationHandler, commandBusHandler)
        {
            _productService = productService;
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("id")]
        public IActionResult GetProductById(Guid productId)
        {
            try
            {
                if (productId == Guid.Empty) return BadRequest(new { IsSuccessStatusCode = false, Errors = "Product id is required" });

                var result = _productService.GetProductById(productId);
                return Ok(new { IsSuccessStatusCode = true, Results = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { IsSuccessStatusCode = false, Errors = ex.Message });
            }
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("Add")]
        public IActionResult AddProduct([FromBody] AddNewProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { IsSuccessStatusCode = false, Errors = ModelState });

                _productService.Add(model);

                if (Errors.Any()) return BadRequest(new { IsSuccessStatusCode = false, Errors });
                return Ok(new { IsSuccessStatusCode = true });
            }
            catch (Exception ex)
            {
                return NotFound(new { IsSuccessStatusCode = false, Errors = ex.Message });
            }
        }
    }
}