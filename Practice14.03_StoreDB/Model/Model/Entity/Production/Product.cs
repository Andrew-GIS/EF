using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model.Entity
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int ModelYear { get; set; }

        public decimal ListPrice { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<Stock> Stocks { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public override string ToString()
        {
            return $"{this.ProductName}";
        }
    }
}