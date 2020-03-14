using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model.Entity
{
    public class Category_Prod
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public ObservableCollection<Product_Prod> Products { get; set; }
    }
}