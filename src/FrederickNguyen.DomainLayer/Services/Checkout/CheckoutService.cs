// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-19-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-19-2018
// ***********************************************************************
// <copyright file="CheckoutService.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using FrederickNguyen.DomainCore.Events;
using FrederickNguyen.DomainCore.Repository;
using FrederickNguyen.DomainCore.Services;
using FrederickNguyen.DomainLayer.AggregatesModels.Carts.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Events;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Repository;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Specification;
using FrederickNguyen.DomainLayer.AggregatesModels.Purchases.Models;

namespace FrederickNguyen.DomainLayer.Services.Checkout
{
    /// <summary>
    /// Class CheckoutService.
    /// </summary>
    public class CheckoutService : IDomainService
    {
        private readonly IProductRepository _productRepository;
        private readonly IRepository<Purchase> _purchaseRepository;
        private readonly IEventDispatcher _eventDispatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutService" /> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="purchaseRepository">The purchase repository.</param>
        /// <param name="eventDispatcher">The event dispatcher.</param>
        public CheckoutService(IProductRepository productRepository, IRepository<Purchase> purchaseRepository, IEventDispatcher eventDispatcher)
        {
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
            _eventDispatcher = eventDispatcher;
        }

        /// <summary>
        /// Customers the can pay.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>PaymentStatus.</returns>
        public PaymentStatus CustomerCanPay(Customer customer)
        {
            return customer.Balance <= 0 ? PaymentStatus.UnpaidBalance : PaymentStatus.Ok;
        }

        /// <summary>
        /// Determines whether this instance [can check out] the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="cart">The cart.</param>
        /// <returns>CheckOutIssue.</returns>
        public CheckOutIssue CanCheckOut(Customer customer, Cart cart)
        {
            var paymentStatus = CustomerCanPay(customer);
            if (!Equals(paymentStatus, PaymentStatus.Ok))
                return CheckOutIssue.FromName(paymentStatus.Name);

            var productState = ProductCanBePurchased(cart);
            return !Equals(productState, ProductState.Ok) ? CheckOutIssue.FromName(productState.Name) : null;
        }

        /// <summary>
        /// Products the can be purchased.
        /// </summary>
        /// <param name="cart">The cart.</param>
        /// <returns>ProductState.</returns>
        /// <exception cref="Exception"></exception>
        public ProductState ProductCanBePurchased(Cart cart)
        {
            foreach (var cartProduct in cart.Products)
            {
                var product = _productRepository.FindById(cartProduct.ProductId);
                var isInStock = new ProductIsInStockSpec(cartProduct).IsSatisfiedBy(product);
                if (!isInStock) return ProductState.NotInStock;
            }
            return ProductState.Ok;
        }

        /// <summary>
        /// Checkouts the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="cart">The cart.</param>
        /// <returns>Purchase.</returns>
        /// <exception cref="System.Exception"></exception>
        public Purchase Checkout(Customer customer, Cart cart)
        {
            var purchase = Purchase.Create(cart);

            _purchaseRepository.Add(purchase);
            cart.Clear();

            //_eventDispatcher.RaiseEvent(new CustomerCheckOutEvent { Purchase = purchase });

            return purchase;
        }
    }
}
