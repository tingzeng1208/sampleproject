using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.products
{
    public interface ICreateProductService
    {
        Product Create(Guid id, string name, decimal price, string manufacturer, int inventory, IEnumerable<string> tags);
    }
}
