using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IOrderRepository _orderRepository;
        private readonly IUpdateOrderService _updateOrderService;

        public CreateOrderService(
            IIdObjectFactory<Order> orderFactory,
            IOrderRepository orderRepository,
            IUpdateOrderService updateOrderService)
        {
            _orderFactory = orderFactory;
            _orderRepository = orderRepository;
            _updateOrderService = updateOrderService;
        }

        public Order Create(Guid id, Guid userId, DateTime orderDate, OrderStatus orderStatus, decimal totalAmount, IList<ProductOrderItem> productOrderList)
        {
            var order = _orderFactory.Create(id);

            _updateOrderService.Update(order, userId, orderDate, orderStatus, totalAmount, productOrderList);

            _orderRepository.Save(order);

            return order;
        }
    }
}
