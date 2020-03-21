using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands (Production)",
                columns: table => new
                {
                    brand_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands (Production)", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "Categories (Production)",
                columns: table => new
                {
                    category_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories (Production)", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "Customers (Sales)",
                columns: table => new
                {
                    customer_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip_code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers (Sales)", x => x.customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "Store (Sales)",
                columns: table => new
                {
                    store_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip_code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store (Sales)", x => x.store_id);
                });

            migrationBuilder.CreateTable(
                name: "Products (Production)",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(nullable: true),
                    model_year = table.Column<int>(nullable: false),
                    list_price = table.Column<decimal>(nullable: false),
                    category_id = table.Column<int>(nullable: false),
                    brand_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products (Production)", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Products (Production)_Brands (Production)_brand_id",
                        column: x => x.brand_id,
                        principalTable: "Brands (Production)",
                        principalColumn: "brand_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products (Production)_Categories (Production)_category_id",
                        column: x => x.category_id,
                        principalTable: "Categories (Production)",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs (Sales)",
                columns: table => new
                {
                    staff_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: false),
                    manager_id = table.Column<int>(nullable: true),
                    store_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs (Sales)", x => x.staff_id);
                    table.ForeignKey(
                        name: "FK_Staffs (Sales)_Store (Sales)_store_id",
                        column: x => x.store_id,
                        principalTable: "Store (Sales)",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stocks (Production)",
                columns: table => new
                {
                    store_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks (Production)", x => new { x.store_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_Stocks (Production)_Products (Production)_product_id",
                        column: x => x.product_id,
                        principalTable: "Products (Production)",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks (Production)_Store (Sales)_store_id",
                        column: x => x.store_id,
                        principalTable: "Store (Sales)",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders (Sales)",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(nullable: false),
                    order_status = table.Column<string>(nullable: true),
                    order_date = table.Column<DateTime>(nullable: false),
                    required_date = table.Column<DateTime>(nullable: false),
                    shipped_date = table.Column<DateTime>(nullable: false),
                    staff_id = table.Column<int>(nullable: false),
                    store_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders (Sales)", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Orders (Sales)_Customers (Sales)_customer_id",
                        column: x => x.customer_id,
                        principalTable: "Customers (Sales)",
                        principalColumn: "customer_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders (Sales)_Staffs (Sales)_staff_id",
                        column: x => x.staff_id,
                        principalTable: "Staffs (Sales)",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders (Sales)_Store (Sales)_store_id",
                        column: x => x.store_id,
                        principalTable: "Store (Sales)",
                        principalColumn: "store_id");
                });

            migrationBuilder.CreateTable(
                name: "Order_Items (Sales)",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    list_price = table.Column<decimal>(nullable: false),
                    discount = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Items (Sales)", x => new { x.order_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_Order_Items (Sales)_Orders (Sales)_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders (Sales)",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Items (Sales)_Products (Production)_product_id",
                        column: x => x.product_id,
                        principalTable: "Products (Production)",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands (Production)",
                columns: new[] { "brand_id", "brand_name" },
                values: new object[,]
                {
                    { 1, "Speedo" },
                    { 2, "Arena" }
                });

            migrationBuilder.InsertData(
                table: "Categories (Production)",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { 1, "Swimming" },
                    { 2, "Foorball" }
                });

            migrationBuilder.InsertData(
                table: "Customers (Sales)",
                columns: new[] { "customer_Id", "city", "email", "first_name", "last_name", "phone", "state", "street", "zip_code" },
                values: new object[,]
                {
                    { 1, "Kharkiv", "a.fedorchenko@intetics.com", "Andrew", "Fedorchenko", "0500505026", "NorthEast", "Gogolya", 64000 },
                    { 2, "Kiev", "a.kolomietc@boing.com", "Anna", "Kolomietc", "095959523", "Central", "Vilisova", 10000 }
                });

            migrationBuilder.InsertData(
                table: "Store (Sales)",
                columns: new[] { "store_id", "city", "email", "phone", "state", "store_name", "street", "zip_code" },
                values: new object[,]
                {
                    { 1, "Kharkiv", "eldorado@kh.com", "079369256", "NorthEast", "Eldorado", "Truda", 6400 },
                    { 2, "Kharkiv", "foxtrot@kh.com", "056869636", "NorthEast", "Foxtrot", "Rubnay", 6400 }
                });

            migrationBuilder.InsertData(
                table: "Products (Production)",
                columns: new[] { "product_id", "brand_id", "category_id", "list_price", "model_year", "product_name" },
                values: new object[,]
                {
                    { 1, 1, 1, 25.21m, 2019, "Water Ball 25x8" },
                    { 2, 2, 2, 80.99m, 2020, "Footbal Ball 13n8" }
                });

            migrationBuilder.InsertData(
                table: "Staffs (Sales)",
                columns: new[] { "staff_id", "active", "email", "first_name", "last_name", "manager_id", "phone", "store_id" },
                values: new object[,]
                {
                    { 1, true, "n.kramorenko@intetics.com", "Nikolay", "Kramorenko", 1, "0502631248", 1 },
                    { 2, true, "l.gurchenko@intetics.com", "Lola", "Gurchenko", 1, "0507879768", 2 }
                });

            migrationBuilder.InsertData(
                table: "Order_Items (Sales)",
                columns: new[] { "order_id", "product_id", "discount", "list_price", "OrderId", "quantity" },
                values: new object[,]
                {
                    { 1, 1, 10m, 50.2m, null, 1 },
                    { 2, 2, 5m, 25.2m, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Orders (Sales)",
                columns: new[] { "order_id", "customer_id", "order_date", "order_status", "required_date", "shipped_date", "staff_id", "store_id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 2, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Processing", new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Stocks (Production)",
                columns: new[] { "store_id", "product_id", "quantity" },
                values: new object[,]
                {
                    { 1, 1, 1020 },
                    { 2, 2, 2100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items (Sales)_OrderId",
                table: "Order_Items (Sales)",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items (Sales)_product_id",
                table: "Order_Items (Sales)",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders (Sales)_customer_id",
                table: "Orders (Sales)",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders (Sales)_staff_id",
                table: "Orders (Sales)",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders (Sales)_store_id",
                table: "Orders (Sales)",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products (Production)_brand_id",
                table: "Products (Production)",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products (Production)_category_id",
                table: "Products (Production)",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs (Sales)_store_id",
                table: "Staffs (Sales)",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks (Production)_product_id",
                table: "Stocks (Production)",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Items (Sales)");

            migrationBuilder.DropTable(
                name: "Stocks (Production)");

            migrationBuilder.DropTable(
                name: "Orders (Sales)");

            migrationBuilder.DropTable(
                name: "Products (Production)");

            migrationBuilder.DropTable(
                name: "Customers (Sales)");

            migrationBuilder.DropTable(
                name: "Staffs (Sales)");

            migrationBuilder.DropTable(
                name: "Brands (Production)");

            migrationBuilder.DropTable(
                name: "Categories (Production)");

            migrationBuilder.DropTable(
                name: "Store (Sales)");
        }
    }
}
