using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.products
{
    public interface IDeleteProductService
    {
        void Delete(Product product);
        void DeleteAll();
    }
}
