using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_new.Models.Orders
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            UserId = order.UserId;
            OrderDate = order.OrderDate;
            OrderStatus = order.OrderStatus;
            TotalAmount = order.TotalAmount;
            ProductOrderList = order.ProductOrderList;
        }

        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public IList<ProductOrderItem> ProductOrderList { get; set; }
    }

}