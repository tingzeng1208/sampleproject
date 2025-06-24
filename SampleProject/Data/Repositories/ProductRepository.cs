using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Core.Services.products;
using Data.Indexes;
using Raven.Client;

namespace Data.Repositories
{
    [AutoRegister]
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IDocumentSession _documentSession;

        public ProductRepository(IDocumentSession documentSession) : base(documentSession)
        {
            _documentSession = documentSession;
        }

        public IEnumerable<Product> Get(string name = null, string manufacturer = null, string tag = null)
        {
            var query = _documentSession.Advanced.DocumentQuery<Product, ProductsListIndex>();

            var hasFirstParameter = false;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where($"Name:*{name}*");
                hasFirstParameter = true;
            }

            if (!string.IsNullOrEmpty(manufacturer))
            {
                if (hasFirstParameter)
                    query = query.AndAlso();

                query = query.WhereEquals("Manufacturer", manufacturer);
            }

            if (tag != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                query = query.WhereEquals("Tags", tag);
            }

            return query.ToList();
        }

        public void DeleteAll()
        {
            base.DeleteAll<ProductsListIndex>();
        }


    }
}
