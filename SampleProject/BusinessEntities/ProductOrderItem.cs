using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class ProductOrderItem
    {
        public string productId { get; set; }  // or use int or Guid depending on your ID type
        public int quantity { get; set; }
    }
}
