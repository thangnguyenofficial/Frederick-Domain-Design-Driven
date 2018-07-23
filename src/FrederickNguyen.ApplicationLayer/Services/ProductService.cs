// ***********************************************************************
// Assembly         : FrederickNguyen.ApplicationLayer
// Author           : thangnd
// Created          : 07-12-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-12-2018
// ***********************************************************************
// <copyright file="ProductService.cs" company="FrederickNguyen.ApplicationLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using AutoMapper;
using FrederickNguyen.ApplicationLayer.DataTransferObjects;
using FrederickNguyen.ApplicationLayer.Models;
using FrederickNguyen.DomainCore.Commands;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Commands;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Repository;

namespace FrederickNguyen.ApplicationLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICommandDispatcher _commandDispatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="commandDispatcher">The command dispatcher.</param>
        public ProductService(IMapper mapper, IProductRepository productRepository, ICommandDispatcher commandDispatcher)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _commandDispatcher = commandDispatcher;
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>ProductDto.</returns>
        public ProductDto GetProductById(Guid productId)
        {
            var product = _productRepository.FindById(productId);
            return _mapper.Map<ProductDto>(product);
        }

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Add(AddNewProductViewModel model)
        {
            var createProductCommand = _mapper.Map<CreateProductCommand>(model);
            _commandDispatcher.Send(createProductCommand);
        }
    }
}
