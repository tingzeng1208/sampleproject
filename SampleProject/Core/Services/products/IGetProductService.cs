using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.products
{
    public interface IGetProductService
    {
        Product GetProduct(Guid id);

        IEnumerable<Product> GetProducts(string name = null, string manufacturer = null, string tag = null);

    }
}
