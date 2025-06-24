using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface IGetOrderService
    {
        IEnumerable<Order> GetOrders(OrderStatus? status = null, Guid? productId = null, Guid? userId = null, DateTime? orderDate = null);

        Order GetOrder(Guid id);
    }
}
