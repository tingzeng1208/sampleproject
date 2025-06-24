using BusinessEntities;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Indexes
{
    public class OrderListIndex : AbstractIndexCreationTask<Order>
    {
        public OrderListIndex()
        {
            Map = orders => from order in orders
                           select new
                           {
                               order.Id,
                               order.UserId,
                               order.OrderStatus,
                               order.OrderDate,
                               order.TotalAmount,
                               productIds = order.ProductOrderList.Select(p => p.productId)
                           };

            Index("productIds", FieldIndexing.NotAnalyzed);
        }
    }
}
