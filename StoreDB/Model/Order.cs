﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreDB.Model
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int ItemsTotal { get; set; }

        public string Phone { get; set; }

        public string DeliveryStreet { get; set; }

        public string DeliveryCity { get; set; }

        public string DeliveryZip { get; set; }

        public IList<OrderItem> OrderItems { get; set; }

        //public IList<OrderStatus> OrderStatuses { get; set; }

    }
}
