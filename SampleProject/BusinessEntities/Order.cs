using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        private IList<ProductOrderItem> _productOrderList;
        private Guid _userId;
        private DateTime _orderDate;
        private OrderStatus _orderStatus;
        private decimal _totalAmount;

        public IList<ProductOrderItem> ProductOrderList
        {
            get => _productOrderList;
            private set => _productOrderList = value;
        }

        public Guid UserId
        {
            get => _userId;
            private set => _userId = value;
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            private set => _orderDate = value;
        }

        public OrderStatus OrderStatus
        {
            get => _orderStatus;
            private set => _orderStatus = value;
        }

        public decimal TotalAmount
        {
            get => _totalAmount;
            private set => _totalAmount = value;
        }

        public void SetTotalAmount(decimal amount)
        {
            _totalAmount = amount;
        }

        public void SetUserId(Guid userId)
        {
            _userId = userId;
        }

        public void SetOrderStatus(OrderStatus orderStatus)
        {
            _orderStatus = orderStatus;
        }

        public void SetOrderDate(DateTime orderdate)
        {
            _orderDate = orderdate;
        }

        public void SetProductOrderList(IList<ProductOrderItem> productOrderList)
        {
            _productOrderList = productOrderList;
        }
    }
}
