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
            optionsBuilder.UseSqlServer(@"database = SomeStoreDB14.3-version2; Trusted_Connection=true");
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
                .Property(p => p.ZipCode)
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
            //modelBuilder.Entity<Staff_Sales>()
            //    .Property(p => p.ManagerId).IsOptional();

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

            //
            //Seed
            //
            #region CustomerSeed
            modelBuilder.Entity<Customer_Sales>().HasData(
                new Customer_Sales() { Id = 1, FirstName = "Andrew", LastName = "Fedorchenko", Phone = "0500505026", Email = "a.fedorchenko@intetics.com", Street = "Gogolya", City = "Kharkiv", State = "NorthEast", ZipCode = 64000},
                new Customer_Sales() { Id = 2, FirstName = "Anna", LastName = "Kolomietc", Phone = "095959523", Email = "a.kolomietc@boing.com", Street = "Vilisova", City = "Kiev", State = "Central", ZipCode = 10000});
            #endregion

            #region OrderSeed
            modelBuilder.Entity<Order_Sales>().HasData(
                new Order_Sales() { Id = 1, CustomerId = 1, OrderStatus = "Delivered", OrderDate = new DateTime(2019, 12, 01), RequiredDate = new DateTime(2020, 1, 1), ShippedDate = new DateTime(2019, 12, 19), StoreId = 1, StaffId = 1 },
                new Order_Sales() { Id = 2, CustomerId = 2, OrderStatus = "In Processing", OrderDate = new DateTime(2020, 03, 01), RequiredDate = new DateTime(2020, 4, 1), ShippedDate = new DateTime(2020, 03, 19), StoreId = 2, StaffId = 2 });
            #endregion

            #region OrderItemSeed
            modelBuilder.Entity<OrderItem_Sales>().HasData(
                new OrderItem_Sales() {OrderItemId = 1, ProductId = 1, Quantity=1, ListPrice=50.2M , Discount=10  },
                new OrderItem_Sales() {OrderItemId = 2, ProductId = 2, Quantity=2, ListPrice=25.2M , Discount=5 });
            #endregion

            #region StaffSeed
            modelBuilder.Entity<Staff_Sales>().HasData(
                new Staff_Sales() {Id = 1, FirstName = "Nikolay", LastName="Kramorenko", Email = "n.kramorenko@intetics.com", Phone = "0502631248", Active = true, StoreId = 1, ManagerId = 1 },
                new Staff_Sales() { Id = 2, FirstName = "Lola", LastName = "Gurchenko", Email = "l.gurchenko@intetics.com", Phone = "0507879768", Active = true, StoreId = 2, ManagerId = 1 });
            #endregion

            #region StoreSeed
            modelBuilder.Entity<Store_Sales>().HasData(
                new Store_Sales() { Id = 1, StoreName = "Eldorado", Phone = "079369256", Email = "eldorado@kh.com", Street = "Truda", City = "Kharkiv", State = "NorthEast", ZipCode = 6400 },
                new Store_Sales() { Id = 2, StoreName = "Foxtrot", Phone = "056869636", Email = "foxtrot@kh.com", Street = "Rubnay", City = "Kharkiv", State = "NorthEast", ZipCode = 6400 }
                );
            #endregion

            #region StockSeed
            modelBuilder.Entity<Stock_Prod>().HasData(
                new Stock_Prod() {StoreId =1, ProductId = 1, Quantity = 1020 },
                new Stock_Prod() {StoreId =2, ProductId = 2, Quantity = 2100 }
                );
            #endregion

            #region ProductSeed
            modelBuilder.Entity<Product_Prod>().HasData(
                new Product_Prod() {Id = 1, ProductName = "Water Ball 25x8", BrandId =1, CategoryId = 1, ModelYear = 2019, ListPrice = 25.21m },
                new Product_Prod() {Id = 2, ProductName = "Footbal Ball 13n8", BrandId =2, CategoryId = 2, ModelYear = 2020, ListPrice = 80.99m }
                );
            #endregion

            #region CategorySeed
            modelBuilder.Entity<Category_Prod>().HasData(
                new Category_Prod() {Id =1, CategoryName = "Swimming" },
                new Category_Prod() {Id =2, CategoryName = "Foorball" }
                );
            #endregion

            #region BrandSeed
            modelBuilder.Entity<Brand_Prod>().HasData(
                new Brand_Prod() { Id = 1, BrandName = "Speedo" },
                new Brand_Prod() { Id = 2, BrandName = "Arena" }
                );
            #endregion
        }
    }
}