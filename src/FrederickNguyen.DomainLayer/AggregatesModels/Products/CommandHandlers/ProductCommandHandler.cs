// ***********************************************************************
// Assembly         : FrederickNguyen.DomainLayer
// Author           : thangnd
// Created          : 07-14-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-14-2018
// ***********************************************************************
// <copyright file="ProductCommandHandler.cs" company="FrederickNguyen.DomainLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading;
using System.Threading.Tasks;
using FrederickNguyen.DomainCore.Events;
using FrederickNguyen.DomainCore.Notification;
using FrederickNguyen.DomainCore.UnitOfWork;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Repository;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Commands;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Events;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Specification;
using MediatR;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Products.CommandHandlers
{
    /// <summary>
    /// Class ProductCommandHandler.
    /// </summary>
    public class ProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCommandHandler"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="eventDispatcher">The event dispatcher.</param>
        public ProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IEventDispatcher eventDispatcher)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _eventDispatcher = eventDispatcher;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors)
                    _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, error.ErrorMessage));
                return Task.CompletedTask;
            }

            var product = Product.Create(request.Name, request.Code, request.Quantity, request.Cost);

            var productAlreadyCreatedSpec = new ProductAlreadyCreatedSpec(product.Code);
            var existingProduct = _productRepository.FindSingleBySpec(productAlreadyCreatedSpec);
            if (existingProduct != null)
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"The product code has already been taken"));
                return Task.CompletedTask;
            }

            //add product
            var productAdded = _productRepository.Add(product);
            if (productAdded == null)
            {
                _eventDispatcher.RaiseEvent(new DomainNotification(request.MessageType, @"new product could not insert"));
                return Task.CompletedTask;
            }
            _unitOfWork.Commit();

            //raise events send email & store event
            _eventDispatcher.RaiseEvent(new ProductCreatedEvent { Product = productAdded });

            return Task.CompletedTask;
        }
    }
}
