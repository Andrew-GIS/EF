using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entity
{
    public class OrderItem_Sales
    {
        public int OrderItemId { get; set; }
        
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal ListPrice { get; set; }

        public decimal Discount { get; set; }

        public Product_Prod Product { get; set; }

        public Order_Sales Order { get; set; }
    }
}