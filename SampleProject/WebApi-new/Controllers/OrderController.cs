using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Xml.Linq;
using BusinessEntities;
using Core.Services.Orders;
using WebApi_new.Models.Orders;

namespace WebApi_new.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;

        public OrderController(ICreateOrderService createOrderService, IDeleteOrderService deleteOrderService, IGetOrderService getOrderService, IUpdateOrderService updateOrderService)
        {
            _createOrderService = createOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
        }
        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            var Order = _createOrderService.Create(orderId, model.UserId, model.OrderDate, model.OrderStatus, model.TotalAmount, model.ProductOrderList);
            return Found(new OrderData(Order));
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            var Order = _getOrderService.GetOrder(orderId);
            if (Order == null)
            {
                return DoesNotExist();
            }

            _updateOrderService.Update(Order, model.UserId, model.OrderDate, model.OrderStatus, model.TotalAmount, model.ProductOrderList);
            return Found(new OrderData(Order));
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            var Order = _getOrderService.GetOrder(orderId);
            if (Order == null)
            {
                return DoesNotExist();
            }
            _deleteOrderService.Delete(Order);
            return Found();
        }

        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid orderId)
        {
            var Order = _getOrderService.GetOrder(orderId);
            if (Order == null)
            {
                return EmptyResult();
            }
            return Found(new OrderData(Order));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders(int skip, int take, OrderStatus? status = null, Guid? productId = null, Guid? userId = null, DateTime? orderDate = null)
        {
            var Orders = _getOrderService.GetOrders(status, productId, userId, orderDate)
                                       .Skip(skip).Take(take)
                                       .Select(q => new OrderData(q))
                                       .ToList();
            return Found(Orders);
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllOrders()
        {
            _deleteOrderService.DeleteAll();
            return Found();
        }


}
}