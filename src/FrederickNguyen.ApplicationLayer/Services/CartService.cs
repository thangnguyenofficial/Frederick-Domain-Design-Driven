// ***********************************************************************
// Assembly         : FrederickNguyen.ApplicationLayer
// Author           : thangnd
// Created          : 07-17-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-17-2018
// ***********************************************************************
// <copyright file="CartService.cs" company="FrederickNguyen.ApplicationLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using AutoMapper;
using FrederickNguyen.ApplicationLayer.DataTransferObjects;
using FrederickNguyen.ApplicationLayer.Models;
using FrederickNguyen.DomainCore.Events;
using FrederickNguyen.DomainCore.Notification;
using FrederickNguyen.DomainCore.UnitOfWork;
using FrederickNguyen.DomainLayer.AggregatesModels.Carts.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Carts.Repository;
using FrederickNguyen.DomainLayer.AggregatesModels.Carts.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Repository;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Repository;
using FrederickNguyen.DomainLayer.AggregatesModels.Purchases.Models;
using FrederickNguyen.DomainLayer.Services.Checkout;

namespace FrederickNguyen.ApplicationLayer.Services
{
    /// <summary>
    /// Class CartService.
    /// </summary>
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly CheckoutService _checkoutDomainService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>The type of the message.</value>
        private string MessageType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartService" /> class.
        /// </summary>
        /// <param name="cartRepository">The cart repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="eventDispatcher">The event dispatcher.</param>
        /// <param name="checkoutDomainService">The checkout domain service.</param>
        /// <param name="customerRepository">The customer repository.</param>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public CartService(ICartRepository cartRepository, IMapper mapper, IEventDispatcher eventDispatcher, CheckoutService checkoutDomainService,
            ICustomerRepository customerRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _eventDispatcher = eventDispatcher;
            _checkoutDomainService = checkoutDomainService;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;

            MessageType = GetType().Name;
        }

        /// <summary>
        /// Gets the by customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>CartDto.</returns>
        public CartDto GetProductsInCartByCustomerId(Guid customerId)
        {
            var cart = _cartRepository.FindSingleBySpec(new CustomerCartSpec(customerId));
            return _mapper.Map<Cart, CartDto>(cart);
        }

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Add(AddProudctToCartViewModel model)
        {
            var customer = _customerRepository.FindById(model.CustomerId);
            if (customer == null)
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(MessageType, string.Format("Customer was not found with this Id: {0}", model.CustomerId)));
                return;
            }

            var product = _productRepository.FindById(model.ProductId);
            if (product == null)
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(MessageType, string.Format("Product was not found with this Id: {0}", model.ProductId)));
                return;
            }

            var cart = _cartRepository.FindSingleBySpec(new CustomerCartSpec(model.CustomerId));
            if (cart == null)
            {
                cart = Cart.Create(customer);
                _cartRepository.Add(cart);
            }

            //Double Dispatch Pattern
            cart.Add(CartProduct.Create(customer, cart, product, model.Quantity));
        }

        /// <summary>
        /// Removes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Remove(RemoveProductFromCartViewModel model)
        {
            var product = _productRepository.FindById(model.ProductId);
            if (product == null)
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(MessageType, string.Format("Product was not found with this Id: {0}", model.ProductId)));
                return;
            }

            var cart = _cartRepository.FindSingleBySpec(new CustomerCartSpec(model.CustomerId));
            if (cart == null)
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(MessageType, string.Format("Cart was not found with this customer Id: {0}", model.CustomerId)));
                return;
            }

            cart.Remove(product);
        }

        /// <summary>
        /// Checks the out.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>CheckOutResultDto.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public CheckOutResultDto CheckOut(Guid customerId)
        {
            var checkOutResultDto = new CheckOutResultDto();

            var cart = _cartRepository.FindSingleBySpec(new CustomerCartSpec(customerId));
            if (cart == null)
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(GetType().Name, string.Format("Cart was not found with this customer Id: {0}", customerId)));
                return null;
            }
            if (!cart.Products.Any())
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(GetType().Name, "Cart was not found any items"));
                return null;
            }

            var customer = _customerRepository.FindById(cart.CustomerId);
            if (customer == null)
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(GetType().Name, string.Format("Customer was not found with this Id: {0}", cart.CustomerId)));
                return null;
            }

            var checkOutIssue = _checkoutDomainService.CanCheckOut(customer, cart);

            if (checkOutIssue == null)
            {
                var purchase = _checkoutDomainService.Checkout(customer, cart);
                checkOutResultDto = _mapper.Map<Purchase, CheckOutResultDto>(purchase);
                _unitOfWork.Commit();
            }
            else
            {
                checkOutResultDto.CheckOutIssue = checkOutIssue;
            }

            return checkOutResultDto;
        }
    }
}