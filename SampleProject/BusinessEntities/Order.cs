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
        private int _orderStatus;
        private decimal _totalAmount;

        public IList<ProductOrderItem> ProductOrderList
        {
            get => _productOrderList;
            set => _productOrderList = value;
        }

        public Guid UserId
        {
            get => _userId;
            set => _userId = value;
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            set => _orderDate = value;
        }

        public int OrderStatus
        {
            get => _orderStatus;
            set => _orderStatus = value;
        }

        public decimal TotalAmount
        {
            get => _totalAmount;
            set => _totalAmount = value;
        }

    }
}
