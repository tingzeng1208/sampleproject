﻿using BusinessEntities;
using Common;
using Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.products
{
        [AutoRegister]
        public class CreateProductService : ICreateProductService
        {
            private readonly IUpdateProductService _updateProductService;
            private readonly IIdObjectFactory<Product> _productFactory;
            private readonly IProductRepository _productRepository;

            public CreateProductService(
                IIdObjectFactory<Product> productFactory,
                IProductRepository productRepository,
                IUpdateProductService updateProductService)
            {
                _productFactory = productFactory;
                _productRepository = productRepository;
                _updateProductService = updateProductService;
            }

            public Product Create(Guid id, string name, decimal price, string manufacturer, int inventory, IEnumerable<string> tags)
            {
                var product = _productFactory.Create(id);
                _updateProductService.Update(product, name, price, manufacturer, inventory, tags);
                _productRepository.Save(product);
                return product;
            }
        }

}
