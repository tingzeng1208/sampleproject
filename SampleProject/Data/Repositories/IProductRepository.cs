using BusinessEntities;
using Data.Repositories;
using System.Collections.Generic;

namespace Core.Services.products
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> Get(string name = null, string manufacturer = null, string tag = null);
        void DeleteAll();
    }
}