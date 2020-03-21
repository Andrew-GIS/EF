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
            optionsBuilder.UseSqlServer(@"database = SomeStoreDB; Trusted_Connection=true");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Stock> Stock_Prods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            //Customer Table Edition
            //
            #region CustomerTable
            modelBuilder.Entity<Customer>()
                .ToTable("Customers (Sales)");
            modelBuilder.Entity<Customer>()
                .Property(p => p.Id)
                .HasColumnName("customer_Id");
            modelBuilder.Entity<Customer>()
                .Property(p => p.FirstName)
                .HasColumnName("first_name");
            modelBuilder.Entity<Customer>()
                .Property(p => p.LastName)
                .HasColumnName("last_name");
            modelBuilder.Entity<Customer>()
                .Property(p => p.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Customer>()
                .Property(p => p.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Customer>()
                .Property(p => p.Street)
                .HasColumnName("street");
            modelBuilder.Entity<Customer>()
                .Property(p => p.City)
                .HasColumnName("city");
            modelBuilder.Entity<Customer>()
                .Property(p => p.State)
                .HasColumnName("state");
            modelBuilder.Entity<Customer>()
                .Property(p => p.ZipCode)
                .HasColumnName("zip_code");
            #endregion

            //
            //Customer-Order connection
            //
            modelBuilder.Entity<Customer>()
                .HasMany<Order>(c => c.Orders)
                .WithOne(o => o.Customer);

            //
            //Order Table Edition
            //
            #region OrderTable
            modelBuilder.Entity<Order>()
                .ToTable("Orders (Sales)");
            modelBuilder.Entity<Order>()
                .Property(p => p.Id)
                .HasColumnName("order_id");
            modelBuilder.Entity<Order>()
                .Property(p => p.CustomerId)
                .HasColumnName("customer_id");
            modelBuilder.Entity<Order>()
                .Property(p => p.OrderStatus)
                .HasColumnName("order_status");
            modelBuilder.Entity<Order>()
                .Property(p => p.OrderDate)
                .HasColumnName("order_date");
            modelBuilder.Entity<Order>()
                .Property(p => p.RequiredDate)
                .HasColumnName("required_date");
            modelBuilder.Entity<Order>()
                .Property(p => p.ShippedDate)
                .HasColumnName("shipped_date");
            modelBuilder.Entity<Order>()
                .Property(p => p.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Order>()
                .Property(p => p.StaffId)
                .HasColumnName("staff_id");
            #endregion

            //
            //Order-Store connection
            //
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Store)
                    .WithMany(s => s.Orders)
                    .OnDelete(DeleteBehavior.NoAction);
            //
            //Order-Staff connection
            //
            modelBuilder.Entity<Order>()
                .HasOne<Staff>(o => o.Staff)
                .WithMany(s => s.Orders);

            //
            //Order-OrderItem connection
            //
            modelBuilder.Entity<Order>()
                .HasMany<OrderItem>(o => o.OrderItems)
                .WithOne(o => o.Order);

            //
            //OrderItem Table Edition
            //
            #region OrderItemTable
            modelBuilder.Entity<OrderItem>()
                .ToTable("Order_Items (Sales)");
            modelBuilder.Entity<OrderItem>()
                .HasKey(p => new { p.OrderItemId, p.ProductId });
            modelBuilder.Entity<OrderItem>()
                .Property(p => p.OrderItemId)
                .HasColumnName("order_id");
            modelBuilder.Entity<OrderItem>()
                .Property(p => p.ProductId)
                .HasColumnName("product_id");
            modelBuilder.Entity<OrderItem>()
                .Property(p => p.Quantity)
                .HasColumnName("quantity");
            modelBuilder.Entity<OrderItem>()
                .Property(p => p.ListPrice)
                .HasColumnName("list_price");
            modelBuilder.Entity<OrderItem>()
                .Property(p => p.Discount)
                .HasColumnName("discount");
            #endregion

            //
            //OrderItem - Products
            //
            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>(o => o.Product)
                .WithMany(p => p.OrderItems);

            //
            //Staff Table Edition
            //
            #region StaffTable
            modelBuilder.Entity<Staff>()
                .ToTable("Staffs (Sales)");
            modelBuilder.Entity<Staff>()
                .Property(p => p.Id)
                .HasColumnName("staff_id");
            modelBuilder.Entity<Staff>()
                .Property(p => p.FirstName)
                .HasColumnName("first_name");
            modelBuilder.Entity<Staff>()
                .Property(p => p.LastName)
                .HasColumnName("last_name");
            modelBuilder.Entity<Staff>()
                .Property(p => p.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Staff>()
                .Property(p => p.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Staff>()
                .Property(p => p.Active)
                .HasColumnName("active");
            modelBuilder.Entity<Staff>()
                .Property(p => p.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Staff>()
                .Property(p => p.ManagerId)
                .HasColumnName("manager_id");
            #endregion

            //
            //Staff-Store connection
            //
            modelBuilder.Entity<Staff>()
                .HasOne<Store>(s => s.Store)
                .WithMany(s => s.Staffs);

            //
            //Store Table Edition
            //
            #region StoreTable
            modelBuilder.Entity<Store>()
                .ToTable("Store (Sales)");
            modelBuilder.Entity<Store>()
                .Property(p => p.Id)
                .HasColumnName("store_id");
            modelBuilder.Entity<Store>()
                .Property(p => p.StoreName)
                .HasColumnName("store_name");
            modelBuilder.Entity<Store>()
                .Property(p => p.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Store>()
                .Property(p => p.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Store>()
                .Property(p => p.Street)
                .HasColumnName("street");
            modelBuilder.Entity<Store>()
                .Property(p => p.City)
                .HasColumnName("city");
            modelBuilder.Entity<Store>()
                .Property(p => p.State)
                .HasColumnName("state");
            modelBuilder.Entity<Store>()
                .Property(p => p.ZipCode)
                .HasColumnName("zip_code");
            #endregion

            //
            //Store-Stock connection
            //
            modelBuilder.Entity<Store>()
                .HasMany<Stock>(s => s.Stocks)
                .WithOne(s => s.Store);

            //
            //Product Table Edition
            //
            #region ProductTable
            modelBuilder.Entity<Product>()
                .ToTable("Products (Production)");
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasColumnName("product_id");
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .HasColumnName("product_name");
            modelBuilder.Entity<Product>()
                .Property(p => p.BrandId)
                .HasColumnName("brand_id");
            modelBuilder.Entity<Product>()
                .Property(p => p.CategoryId)
                .HasColumnName("category_id");
            modelBuilder.Entity<Product>()
                .Property(p => p.ModelYear)
                .HasColumnName("model_year");
            modelBuilder.Entity<Product>()
                .Property(p => p.ListPrice)
                .HasColumnName("list_price");
            #endregion

            //
            //Product-Stock connection
            //
            modelBuilder.Entity<Product>()
                .HasMany<Stock>(p => p.Stocks)
                .WithOne(s => s.Product);

            //
            //Product-Categories connection
            //
            modelBuilder.Entity<Product>()
                .HasOne<Category>(p => p.Category)
                .WithMany(c => c.Products);

            //
            //Product-Brand connection
            //
            modelBuilder.Entity<Product>()
                .HasOne<Brand>(p => p.Brand)
                .WithMany(b => b.Products);

            //
            //Stock Table Edition
            //
            #region StockTable
            modelBuilder.Entity<Stock>()
                .ToTable("Stocks (Production)");
            modelBuilder.Entity<Stock>()
                .HasKey(p => new { p.StoreId, p.ProductId });
            modelBuilder.Entity<Stock>()
                .Property(p => p.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Stock>()
                .Property(p => p.ProductId)
                .HasColumnName("product_id");
            modelBuilder.Entity<Stock>()
                .Property(p => p.Quantity)
                .HasColumnName("quantity");
            #endregion

            //
            //Category Table Edition
            //
            #region CategoryTable
            modelBuilder.Entity<Category>()
                .ToTable("Categories (Production)");
            modelBuilder.Entity<Category>()
                .Property(p => p.Id)
                .HasColumnName("category_id");
            modelBuilder.Entity<Category>()
                .Property(p => p.CategoryName)
                .HasColumnName("category_name");
            #endregion

            //
            //Brand table Edition
            //
            #region BrandTable
            modelBuilder.Entity<Brand>()
                .ToTable("Brands (Production)");
            modelBuilder.Entity<Brand>()
                .Property(p => p.Id)
                .HasColumnName("brand_id");
            modelBuilder.Entity<Brand>()
                .Property(p => p.BrandName)
                .HasColumnName("brand_name");
            #endregion

            //
            //Seed
            //
            #region CustomerSeed
            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    Id = 1,
                    FirstName = "Andrew",
                    LastName = "Fedorchenko",
                    Phone = "0500505026",
                    Email = "a.fedorchenko@intetics.com",
                    Street = "Gogolya",
                    City = "Kharkiv",
                    State = "NorthEast",
                    ZipCode = 64000
                },
                new Customer()
                {
                    Id = 2,
                    FirstName = "Anna",
                    LastName = "Kolomietc",
                    Phone = "095959523",
                    Email = "a.kolomietc@boing.com",
                    Street = "Vilisova",
                    City = "Kiev",
                    State = "Central",
                    ZipCode = 10000
                });
            #endregion

            #region OrderSeed
            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    Id = 1,
                    CustomerId = 1,
                    OrderStatus = "Delivered",
                    OrderDate = new DateTime(2019, 12, 01),
                    RequiredDate = new DateTime(2020, 1, 1),
                    ShippedDate = new DateTime(2019, 12, 19),
                    StoreId = 1,
                    StaffId = 1
                },
                new Order()
                {
                    Id = 2,
                    CustomerId = 2,
                    OrderStatus = "In Processing",
                    OrderDate = new DateTime(2020, 3, 01),
                    RequiredDate = new DateTime(2020, 4, 1),
                    ShippedDate = new DateTime(2020, 3, 19),
                    StoreId = 2,
                    StaffId = 2
                },
                new Order()
                {
                    Id = 3,
                    CustomerId = 1,
                    OrderStatus = "In Processing",
                    OrderDate = new DateTime(2019, 1, 03),
                    RequiredDate = new DateTime(2020, 01, 29),
                    ShippedDate = new DateTime(2020, 02, 02),
                    StoreId = 2,
                    StaffId = 2
                },
                new Order()
                {
                    Id = 4,
                    CustomerId = 2,
                    OrderStatus = "In Delivered",
                    OrderDate = new DateTime(2018, 3, 03),
                    RequiredDate = new DateTime(2020, 4, 13),
                    ShippedDate = new DateTime(2020, 6, 29),
                    StoreId = 1,
                    StaffId = 1
                });
            #endregion

            #region OrderItemSeed
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem()
                {
                    OrderItemId = 1,
                    ProductId = 1,
                    Quantity = 1,
                    ListPrice = 50.2M,
                    Discount = 10
                },
                new OrderItem()
                {
                    OrderItemId = 2,
                    ProductId = 2,
                    Quantity = 2,
                    ListPrice = 25.2M,
                    Discount = 5
                });
            #endregion

            #region StaffSeed
            modelBuilder.Entity<Staff>().HasData(
                new Staff()
                {
                    Id = 1,
                    FirstName = "Nikolay",
                    LastName = "Kramorenko",
                    Email = "n.kramorenko@intetics.com",
                    Phone = "0502631248",
                    Active = false,
                    StoreId = 1,
                    ManagerId = 1
                },
                new Staff()
                {
                    Id = 2,
                    FirstName = "Lola",
                    LastName = "Gurchenko",
                    Email = "l.gurchenko@intetics.com",
                    Phone = "0507879768",
                    Active = true,
                    StoreId = 2,
                    ManagerId = 1
                });
            #endregion

            #region StoreSeed
            modelBuilder.Entity<Store>().HasData(
                new Store()
                {
                    Id = 1,
                    StoreName = "Eldorado",
                    Phone = "079369256",
                    Email = "eldorado@kh.com",
                    Street = "Truda",
                    City = "Kharkiv",
                    State = "NorthEast",
                    ZipCode = 6400
                },
                new Store()
                {
                    Id = 2,
                    StoreName = "Foxtrot",
                    Phone = "056869636",
                    Email = "foxtrot@kh.com",
                    Street = "Rubnay",
                    City = "Kharkiv",
                    State = "NorthEast",
                    ZipCode = 6400
                }
                );
            #endregion

            #region StockSeed
            modelBuilder.Entity<Stock>().HasData(
                new Stock()
                {
                    StoreId = 1,
                    ProductId = 1,
                    Quantity = 1020
                },
                new Stock()
                {
                    StoreId = 2,
                    ProductId = 2,
                    Quantity = 2100
                }
                );
            #endregion

            #region ProductSeed
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    ProductName = "Water Ball 25x8",
                    BrandId = 1,
                    CategoryId = 1,
                    ModelYear = 2019,
                    ListPrice = 25.21m
                },
                new Product()
                {
                    Id = 2,
                    ProductName = "Footbal Ball 13n8",
                    BrandId = 2,
                    CategoryId = 2,
                    ModelYear = 2020,
                    ListPrice = 80.99m
                }
                );
            #endregion

            #region CategorySeed
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    CategoryName = "Swimming"
                },
                new Category()
                {
                    Id = 2,
                    CategoryName = "Foorball"
                }
                );
            #endregion

            #region BrandSeed
            modelBuilder.Entity<Brand>().HasData(
                new Brand()
                {
                    Id = 1,
                    BrandName = "Speedo"
                },
                new Brand()
                {
                    Id = 2,
                    BrandName = "Arena"
                }
                );
            #endregion
        }
    }
}