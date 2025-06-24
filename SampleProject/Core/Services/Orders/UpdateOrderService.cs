using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class UpdateOrderService : IUpdateOrderService
    {
        public void Update(Order order, Guid userId, DateTime orderDate, OrderStatus orderStatus, decimal totalAmount, IList<ProductOrderItem> productOrderList)
        {
            order.SetUserId(userId);
            order.SetOrderDate(orderDate);
            order.SetOrderStatus(orderStatus);
            order.SetTotalAmount(totalAmount);
            order.SetProductOrderList(productOrderList);          
            
        }
    }
}
