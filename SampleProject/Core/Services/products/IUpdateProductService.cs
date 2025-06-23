using BusinessEntities;
using System.Collections.Generic;

namespace Core.Services.products
{
    public interface IUpdateProductService
    {
        void Update(Product product, string name, decimal price, string manufacturer, int inventory, IEnumerable<string> tags);
    }
}