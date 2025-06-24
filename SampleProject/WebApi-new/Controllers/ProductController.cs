using Core.Services.Users;
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

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
        private readonly ICreateProductService _createProductService;
        private readonly IDeleteProductService _deleteUserService;
        private readonly IGetUserService _getUserService;
        private readonly IUpdateUserService _updateUserService;

        //public ProductController(ICreateProductService createProductService, IDeleteUserService deleteUserService, IGetUserService getUserService, IUpdateUserService updateUserService)
        //{
           // _createProductService = createProductService;
           // _deleteUserService = deleteUserService;
           // _getUserService = getUserService;
           //_updateUserService = updateUserService;
        //}

        public ProductController(ICreateProductService createProductService)
        {
            _createProductService = createProductService;
        }

        [Route("{productId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct(Guid productId, [FromBody] ProductModel model)
        {

            var product = _createProductService.Create(productId, model.Name, model.Price, model.Manufacturer, model.Inventory, model.Tags);
            return Found(new ProductData(product));
        }

    }
}