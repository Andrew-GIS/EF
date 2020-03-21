using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entity
{
    public class Stock_Prod
    {
        public int Quantity { get; set; }

        public int StoreId { get; set; }

        public Store_Sales Store { get; set; }

        public int ProductId { get; set; }

        public Product_Prod Product { get; set; }
    }
}