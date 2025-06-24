using Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace BusinessEntities
{
    public class Product: IdNameObject
    {
        private readonly List<string> _tags = new List<string>();
        private decimal _price;
        private string _manufacturer;
        private int _inventory;        

        public decimal Price
        {
            get => _price;
            private set => _price = value;
        }

        public IEnumerable<string> Tags
        {
            get => _tags;
            private set => _tags.Initialize(value);
        }

        // Manufacturer
        public string Manufacturer
        {
            get => _manufacturer;
            private set => _manufacturer = value;
        }

        // Inventory
        public int Inventory
        {
            get => _inventory;
            private set => _inventory = value;
        }

        public void SetManufacturer(string manufacturer)
        {
            if (string.IsNullOrEmpty(manufacturer))
            {
                throw new ArgumentNullException("Manufacturer was not provided.");
            }
            _manufacturer = manufacturer;
        }

        public void setPrice(decimal price)
        {
            if (price > 0)
            {
                _price = price;
            }
        }

        public void SetInventory(int inventory)
        {
            _inventory = inventory;
        }

        public void SetTags(IEnumerable<string> tags)
        {
            _tags.Initialize(tags);
        }
    }
}
