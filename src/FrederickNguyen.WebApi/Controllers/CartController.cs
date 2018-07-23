// ***********************************************************************
// Assembly         : FrederickNguyen.WebApi
// Author           : thangnd
// Created          : 07-17-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-17-2018
// ***********************************************************************
// <copyright file="CartController.cs" company="FrederickNguyen.WebApi">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using FrederickNguyen.ApplicationLayer.Models;
using FrederickNguyen.ApplicationLayer.Services;
using FrederickNguyen.DomainCore.Commands;
using FrederickNguyen.DomainCore.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FrederickNguyen.WebApi.Controllers
{
    /// <summary>
    /// Class CartController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/Cart")]
    public class CartController : ApiController
    {
        /// <summary>
        /// The cart service
        /// </summary>
        private readonly ICartService _cartService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartController" /> class.
        /// </summary>
        /// <param name="cartService">The cart service.</param>
        /// <param name="notificationHandler">The notification handler.</param>
        /// <param name="commandBusHandler">The command bus handler.</param>
        public CartController(ICartService cartService, INotificationHandler<DomainNotification> notificationHandler,
            ICommandDispatcher commandBusHandler) : base(notificationHandler, commandBusHandler)
        {
            _cartService = cartService;
        }

        /// <summary>
        /// Gets the by customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("customer")]
        public IActionResult GetByCustomerId(Guid customerId)
        {

            try
            {
                if (customerId == Guid.Empty) return BadRequest(new { IsSuccessStatusCode = false, Errors = "Customer id is required" });

                var result = _cartService.GetProductsInCartByCustomerId(customerId);
                return Ok(new { IsSuccessStatusCode = true, Results = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { IsSuccessStatusCode = false, Errors = ex.Message });
            }
        }

        /// <summary>
        /// Adds to cart.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("add")]
        public IActionResult AddToCart([FromBody] AddProudctToCartViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { IsSuccessStatusCode = false, Errors = ModelState });

                _cartService.Add(model);

                if (Errors.Any()) return BadRequest(new { IsSuccessStatusCode = false, Errors });
                return Ok(new { IsSuccessStatusCode = true });
            }
            catch (Exception ex)
            {
                return NotFound(new { IsSuccessStatusCode = false, Errors = ex.Message });
            }
        }

        /// <summary>
        /// Removes the product from cart.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("remove")]
        public IActionResult RemoveProductFromCart([FromBody] RemoveProductFromCartViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { IsSuccessStatusCode = false, Errors = ModelState });

                _cartService.Remove(model);

                if (Errors.Any()) return BadRequest(new { IsSuccessStatusCode = false, Errors });
                return Ok(new { IsSuccessStatusCode = true });
            }
            catch (Exception ex)
            {
                return NotFound(new { IsSuccessStatusCode = false, Errors = ex.Message });
            }
        }

        /// <summary>
        /// Removes the product from cart.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("checkout")]
        public IActionResult Checkout(Guid customerId)
        {
            try
            {
                if (customerId == Guid.Empty) return BadRequest(new { IsSuccessStatusCode = false, Errors = "Customer id is required" });

                var result = _cartService.CheckOut(customerId);
                if (Errors.Any()) return BadRequest(new { IsSuccessStatusCode = false, Errors });

                return Ok(new { IsSuccessStatusCode = true, Results = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { IsSuccessStatusCode = false, Errors = ex.Message });
            }
        }
    }
}