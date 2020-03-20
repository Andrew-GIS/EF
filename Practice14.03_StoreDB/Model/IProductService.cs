using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IProductService
    {
        public IEnumerable<Product> GetProduct();
    }
}
