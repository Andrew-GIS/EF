using Microsoft.EntityFrameworkCore;
using SportShop.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportShop.DAL
{
    public class StoreDBContext: DbContext
    {
       public DbSet<Product> Products { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"DataBase=SportShopDB;Trusted_Connection=True");
        }
    }
}
