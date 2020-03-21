using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model.Entity
{
    public class Brand
    {
        public int Id { get; set; }

        public string BrandName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}