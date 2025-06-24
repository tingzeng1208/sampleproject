
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using WebApi_new.Controllers;
using WebApi_new.Models.Products;
using Core.Services.products;
using System.Diagnostics;
using System.Xml.Linq;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
        private readonly ICreateProductService _createProductService;
        private readonly IDeleteProductService _deleteProductService;
        private readonly IGetProductService _getProductService;
        private readonly IUpdateProductService _updateProductService;

        public ProductController(ICreateProductService createproductservice, IDeleteProductService deleteProductservice, IGetProductService getProductservice, IUpdateProductService updateProductservice)
        {
            _createProductService = createproductservice;
            _deleteProductService = deleteProductservice;
            _getProductService = getProductservice;
            _updateProductService = updateProductservice;
        }

        [Route("{productId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct(Guid productId, [FromBody] ProductModel model)
        {

            var product = _createProductService.Create(productId, model.Name, model.Price, model.Manufacturer, model.Inventory, model.Tags);
            return Found(new ProductData(product));
        }

        [Route("{productId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateProduct(Guid productId, [FromBody] ProductModel model)
        {
            var product = _getProductService.GetProduct(productId);
            if (product == null)
            {
                return DoesNotExist();
            }
            _updateProductService.Update(product, model.Name, model.Price, model.Manufacturer, model.Inventory, model.Tags);
            return Found(new ProductData(product));
        }

        [Route("{productId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(Guid productId)
        {
            var Product = _getProductService.GetProduct(productId);
            if (Product == null)
            {
                return DoesNotExist();
            }
            _deleteProductService.Delete(Product);
            return Found();
        }

        [Route("{productId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetProduct(Guid productId)
        {
            var product = _getProductService.GetProduct(productId);
            if (product == null)
            {
                return EmptyResult();
            }
            return Found(new ProductData(product));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetProducts(int skip, int take, string name = null, string manufacturer = null)
        {
            var Products = _getProductService.GetProducts(name, manufacturer)
                                       .Skip(skip).Take(take)
                                       .Select(q => new ProductData(q))
                                       .ToList();
            return Found(Products);
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllProducts()
        {
            _deleteProductService.DeleteAll();
            return Found();
        }

        [Route("list/tag")]
        [HttpGet]
        public HttpResponseMessage GetProductsByTag(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                return DoesNotExist();
            }
            var Products = _getProductService.GetProducts(null, null, tag)
                                       .ToList();

            var ProductDataList = Products.Select(u => new ProductData(u));
            return Found(ProductDataList);
        }

    }
}