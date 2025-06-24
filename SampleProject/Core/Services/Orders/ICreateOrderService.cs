using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface ICreateOrderService
    {
        Order Create(Guid id, Guid userId, DateTime orderDate, OrderStatus orderStatus, decimal totalAmount, IList<ProductOrderItem> productOrderList);
    }
}
