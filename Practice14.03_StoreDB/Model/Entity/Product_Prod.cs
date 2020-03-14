using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model.Entity
{
    public class Product_Prod
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int ModelYear { get; set; }

        public decimal ListPrice { get; set; }

        public ObservableCollection<OrderItem_Sales> OrderItems { get; set; }

        public ObservableCollection<Stock_Prod> Stocks { get; set; }

        public int CategoryId { get; set; }

        public Category_Prod Category { get; set; }

        public int BrandId { get; set; }

        public Brand_Prod Brand { get; set; }
    }
}