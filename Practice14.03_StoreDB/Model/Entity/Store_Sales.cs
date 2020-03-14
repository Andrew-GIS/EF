using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model.Entity
{
    public class Store_Sales
    {
        public int Id { get; set; }

        public string StoreName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }

        public ObservableCollection<Order_Sales> Orders { get; set; }

        public ObservableCollection<Staff_Sales> Staffs { get; set; }

        public ObservableCollection<Stock_Prod> Stocks { get; set; }
    }
}