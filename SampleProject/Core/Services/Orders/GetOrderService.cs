using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
        [AutoRegister]
        public class GetOrderService : IGetOrderService
        {
            private readonly IOrderRepository _orderRepository;

            public GetOrderService(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public IEnumerable<Order> GetOrders(OrderStatus? status = null, Guid? productId = null, Guid? userId = null, DateTime? orderDate = null)
            {
                return _orderRepository.Get(status, productId, userId, orderDate);
            }

            public Order GetOrder(Guid id)
            {
                return _orderRepository.Get(id);
            }
        }
}
