using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{

        public interface IOrderRepository : IRepository<Order>
        {
            IEnumerable<Order> Get(OrderStatus? status = null, Guid? productId = null, Guid? userId = null, DateTime? orderDate = null);
            void DeleteAll();
        }

}
