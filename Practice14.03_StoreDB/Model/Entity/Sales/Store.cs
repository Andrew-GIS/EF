﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model.Entity
{
    public class Store
    {
        public int Id { get; set; }

        public string StoreName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Staff> Staffs { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}