using Microsoft.EntityFrameworkCore;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ProductService : IProductService
    {
        private StoreContext context;

        public ProductService()
        {
            context = new StoreContext();
        }
        public IEnumerable<Product> GetProduct()
        {
            return this.context.Products.Include(prod => prod.Stocks).Include(prod => prod.Category).Include(prod => prod.Brand);
        }
    }
}
