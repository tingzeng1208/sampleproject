using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.products
{
    [AutoRegister]
    internal class UpdateProductService : IUpdateProductService
    {
        public void Update(Product product, string name, decimal price, string manufacturer, int inventory, IEnumerable<string> tags)
        {
            product.SetName(name);
            product.SetManufacturer(manufacturer);
            product.setPrice(price);
            product.SetInventory(inventory);
            product.SetTags(tags);

        }
    }
}
