using BusinessEntities;
using Common;
using System.Collections.Generic;

namespace WebApi_new.Models.Products
{
    public class ProductData : IdObjectData
    {
        public ProductData(Product product) : base(product)
        {
            Name = product.Name;
            Manufacturer = product.Manufacturer;
            Price = product.Price;
            Inventory = product.Inventory;
            Tags = product.Tags;
        }

        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
