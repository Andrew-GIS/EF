using Microsoft.EntityFrameworkCore;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class StoreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"database = SomeStoreDB14.3; Trusted_Connection=true");
        }

        public DbSet<Customer_Sales> Customers { get; set; }
        public DbSet<Order_Sales> Orders { get; set; }
        public DbSet<OrderItem_Sales> OrderItems { get; set; }
        public DbSet<Staff_Sales> Staffs { get; set; }
        public DbSet<Store_Sales> Stores { get; set; }
        public DbSet<Stock_Prod> Stock_Prods { get; set; }
        public DbSet<Product_Prod> Products { get; set; }
        public DbSet<Category_Prod> Categories { get; set; }
        public DbSet<Brand_Prod> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            //Customer Table Edition
            //
            modelBuilder.Entity<Customer_Sales>()
                .ToTable("Customers (Sales)");
            modelBuilder.Entity<Customer_Sales>()
                .Property(p => p.Id)
                .HasColumnName("customer_Id");
            modelBuilder.Entity<Customer_Sales>()
                .Property(p => p.FirstName)
                .HasColumnName("first_name");
            modelBuilder.Entity<Customer_Sales>()
                .Property(p => p.LastName)
                .HasColumnName("last_name");
            modelBuilder.Entity<Customer_Sales>()
                .Property(p => p.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Customer_Sales>()
                .Property(p => p.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Customer_Sales>()
                .Property(p => p.Street)
                .HasColumnName("street");
            modelBuilder.Entity<Customer_Sales>()
                .Property(p => p.City)
                .HasColumnName("city");
            modelBuilder.Entity<Customer_Sales>()
                .Property(p => p.State)
                .HasColumnName("state");
            modelBuilder.Entity<Customer_Sales>()
                .Property(p => p.ZipDode)
                .HasColumnName("zip_code");

            //Customer-Order connection
            modelBuilder.Entity<Customer_Sales>()
                .HasMany<Order_Sales>(c => c.Orders)
                .WithOne(o => o.Customer);

            //
            //Order Table Edition
            //
            modelBuilder.Entity<Order_Sales>()
                .ToTable("Orders (Sales)");
            modelBuilder.Entity<Order_Sales>()
                .Property(p => p.Id)
                .HasColumnName("order_id");
            modelBuilder.Entity<Order_Sales>()
                .Property(p => p.CustomerId)
                .HasColumnName("customer_id");
            modelBuilder.Entity<Order_Sales>()
                .Property(p => p.OrderStatus)
                .HasColumnName("order_status");
            modelBuilder.Entity<Order_Sales>()
                .Property(p => p.OrderDate)
                .HasColumnName("order_date");
            modelBuilder.Entity<Order_Sales>()
                .Property(p => p.RequiredDate)
                .HasColumnName("required_date");
            modelBuilder.Entity<Order_Sales>()
                .Property(p => p.ShippedDate)
                .HasColumnName("shipped_date");
            modelBuilder.Entity<Order_Sales>()
                .Property(p => p.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Order_Sales>()
                .Property(p => p.StaffId)
                .HasColumnName("staff_id");

            //Order-Store
            modelBuilder.Entity<Order_Sales>()
                .HasOne(o => o.Store)
                    .WithMany(s => s.Orders)
                    .OnDelete(DeleteBehavior.NoAction);

            //Order-Staff connection
            modelBuilder.Entity<Order_Sales>()
                .HasOne<Staff_Sales>(o => o.Staff)
                .WithMany(s => s.Orders);

            //Order-OrderItem
            modelBuilder.Entity<Order_Sales>()
                .HasMany<OrderItem_Sales>(o => o.OrderItems)
                .WithOne(o => o.Order);

            //
            //OrderItem Table Edition
            //
            modelBuilder.Entity<OrderItem_Sales>()
                .ToTable("Order_Items (Sales)");
            modelBuilder.Entity<OrderItem_Sales>()
                .HasKey(p => new { p.OrderItemId, p.ProductId });
            modelBuilder.Entity<OrderItem_Sales>()
                .Property(p => p.OrderItemId)
                .HasColumnName("order_id");
            modelBuilder.Entity<OrderItem_Sales>()
                .Property(p => p.ProductId)
                .HasColumnName("product_id");
            modelBuilder.Entity<OrderItem_Sales>()
                .Property(p => p.Quantity)
                .HasColumnName("quantity");
            modelBuilder.Entity<OrderItem_Sales>()
                .Property(p => p.ListPrice)
                .HasColumnName("list_price");
            modelBuilder.Entity<OrderItem_Sales>()
                .Property(p => p.Discount)
                .HasColumnName("discount");

            //OrderItem - Products
            modelBuilder.Entity<OrderItem_Sales>()
                .HasOne<Product_Prod>(o => o.Product)
                .WithMany(p => p.OrderItems);

            //
            //Staff Table Edition
            //
            modelBuilder.Entity<Staff_Sales>()
                .ToTable("Staffs (Sales)");
            modelBuilder.Entity<Staff_Sales>()
                .Property(p => p.Id)
                .HasColumnName("staff_id");
            modelBuilder.Entity<Staff_Sales>()
                .Property(p => p.FirstName)
                .HasColumnName("first_name");
            modelBuilder.Entity<Staff_Sales>()
                .Property(p => p.LastName)
                .HasColumnName("last_name");
            modelBuilder.Entity<Staff_Sales>()
                .Property(p => p.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Staff_Sales>()
                .Property(p => p.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Staff_Sales>()
                .Property(p => p.Active)
                .HasColumnName("active");
            modelBuilder.Entity<Staff_Sales>()
                .Property(p => p.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Staff_Sales>()
                .Property(p => p.ManagerId)
                .HasColumnName("manager_id");

            //Staff-Store connection
            modelBuilder.Entity<Staff_Sales>()
                .HasOne<Store_Sales>(s => s.Store)
                .WithMany(s => s.Staffs);

            //
            //Store Table Edition
            //
            modelBuilder.Entity<Store_Sales>()
                .ToTable("Store (Sales)");
            modelBuilder.Entity<Store_Sales>()
                .Property(p => p.Id)
                .HasColumnName("store_id");
            modelBuilder.Entity<Store_Sales>()
                .Property(p => p.StoreName)
                .HasColumnName("store_name");
            modelBuilder.Entity<Store_Sales>()
                .Property(p => p.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Store_Sales>()
                .Property(p => p.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Store_Sales>()
                .Property(p => p.Street)
                .HasColumnName("street");
            modelBuilder.Entity<Store_Sales>()
                .Property(p => p.City)
                .HasColumnName("city");
            modelBuilder.Entity<Store_Sales>()
                .Property(p => p.State)
                .HasColumnName("state");
            modelBuilder.Entity<Store_Sales>()
                .Property(p => p.ZipCode)
                .HasColumnName("zip_code");

            //Store-Stock connection
            modelBuilder.Entity<Store_Sales>()
                .HasMany<Stock_Prod>(s => s.Stocks)
                .WithOne(s => s.Store);

            //
            //Product Table Edition
            //
            modelBuilder.Entity<Product_Prod>()
                .ToTable("Products (Production)");
            modelBuilder.Entity<Product_Prod>()
                .Property(p => p.Id)
                .HasColumnName("product_id");
            modelBuilder.Entity<Product_Prod>()
                .Property(p => p.ProductName)
                .HasColumnName("product_name");
            modelBuilder.Entity<Product_Prod>()
                .Property(p => p.BrandId)
                .HasColumnName("brand_id");
            modelBuilder.Entity<Product_Prod>()
                .Property(p => p.CategoryId)
                .HasColumnName("category_id");
            modelBuilder.Entity<Product_Prod>()
                .Property(p => p.ModelYear)
                .HasColumnName("model_year");
            modelBuilder.Entity<Product_Prod>()
                .Property(p => p.ListPrice)
                .HasColumnName("list_price");

            //Product-Stock connection
            modelBuilder.Entity<Product_Prod>()
                .HasMany<Stock_Prod>(p => p.Stocks)
                .WithOne(s => s.Product);

            //Product-Categories connection
            modelBuilder.Entity<Product_Prod>()
                .HasOne<Category_Prod>(p => p.Category)
                .WithMany(c => c.Products);

            //Product-Brand connection
            modelBuilder.Entity<Product_Prod>()
                .HasOne<Brand_Prod>(p => p.Brand)
                .WithMany(b => b.Products);

            //
            //Stock Table Edition
            //
            modelBuilder.Entity<Stock_Prod>()
                .ToTable("Stocks (Production)");
            modelBuilder.Entity<Stock_Prod>()
                .HasKey(p => new { p.StoreId, p.ProductId });
            modelBuilder.Entity<Stock_Prod>()
                .Property(p => p.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Stock_Prod>()
                .Property(p => p.ProductId)
                .HasColumnName("product_id");
            modelBuilder.Entity<Stock_Prod>()
                .Property(p => p.Quantity)
                .HasColumnName("quantity");

            //
            //Category Table Edition
            //
            modelBuilder.Entity<Category_Prod>()
                .ToTable("Categories (Production)");
            modelBuilder.Entity<Category_Prod>()
                .Property(p => p.Id)
                .HasColumnName("category_id");
            modelBuilder.Entity<Category_Prod>()
                .Property(p => p.CategoryName)
                .HasColumnName("category_name");

            //
            //Brand table Edition
            //
            modelBuilder.Entity<Brand_Prod>()
                .ToTable("Brands (Production)");
            modelBuilder.Entity<Brand_Prod>()
                .Property(p => p.Id)
                .HasColumnName("brand_id");
            modelBuilder.Entity<Brand_Prod>()
                .Property(p => p.BrandName)
                .HasColumnName("brand_name");
        }
    }
}