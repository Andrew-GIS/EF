using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class table_Created : Migration
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
                    store_id = table.Column<int>(nullable: false),
                    manager_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs (Sales)", x => x.staff_id);
                    table.ForeignKey(
                        name: "FK_Staffs (Sales)_Store (Sales)_store_id",
                        column: x => x.store_id,
                        principalTable: "Store (Sales)",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
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
                    customer_id = table.Column<string>(nullable: true),
                    order_status = table.Column<string>(nullable: true),
                    order_date = table.Column<DateTime>(nullable: false),
                    required_date = table.Column<DateTime>(nullable: false),
                    shipped_date = table.Column<DateTime>(nullable: false),
                    CustomerId1 = table.Column<int>(nullable: true),
                    staff_id = table.Column<int>(nullable: false),
                    store_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders (Sales)", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Orders (Sales)_Customers (Sales)_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers (Sales)",
                        principalColumn: "customer_Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items (Sales)_OrderId",
                table: "Order_Items (Sales)",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items (Sales)_product_id",
                table: "Order_Items (Sales)",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders (Sales)_CustomerId1",
                table: "Orders (Sales)",
                column: "CustomerId1");

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
