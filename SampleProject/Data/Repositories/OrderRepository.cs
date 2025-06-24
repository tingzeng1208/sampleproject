using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    [AutoRegister]
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly IDocumentSession _documentSession;

        public OrderRepository(IDocumentSession documentSession) : base(documentSession)
        {
            _documentSession = documentSession;
        }

        public IEnumerable<Order> Get(OrderStatus? status = null, Guid? productId = null, Guid? userId = null, DateTime? orderDate = null)            
        {
            var query = _documentSession.Advanced.DocumentQuery<Order, OrderListIndex>();


            var hasParameter = false;

            if (userId != null)
            {
                query = query.WhereEquals("UserId", userId.Value);
                hasParameter = true;
            }

            if (status != null)
            {
                if (hasParameter) query = query.AndAlso();
                query = query.WhereEquals("OrderStatus", (int)status);
                hasParameter = true;
            }

            if (productId != null)
            {
                if (hasParameter) query = query.AndAlso();
                query = query.WhereEquals("productIds", productId.Value.ToString());
                hasParameter = true;
            }

            if (orderDate != null)
            {
                if (hasParameter)
                {
                    query = query.AndAlso();
                    query = query.WhereEquals("OrderDate", orderDate.Value);
                }
            }

            return query.ToList();
        }

        public void DeleteAll()
        {
            base.DeleteAll<OrderListIndex>();
        }
    }
}
