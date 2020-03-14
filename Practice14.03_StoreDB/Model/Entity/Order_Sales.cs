using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model.Entity
{
    public class Order_Sales
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }

        public string OrderStatus { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime ShippedDate { get; set; }
        
        public Customer_Sales Customer { get; set; }

        public ObservableCollection<OrderItem_Sales> OrderItems { get; set; }

        public int StaffId { get; set; }

        public Staff_Sales Staff { get; set; }

        public int StoreId { get; set; }

        public Store_Sales Store { get; set; }
    }
}