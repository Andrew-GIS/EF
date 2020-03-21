using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entity
{
    public class Stock
    {
        public int StoreId { get; set; }

        public Store Store { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Quantity} items";
        }
    }
}