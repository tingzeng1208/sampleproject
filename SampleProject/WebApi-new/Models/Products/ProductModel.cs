using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_new.Models.Products
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }

}