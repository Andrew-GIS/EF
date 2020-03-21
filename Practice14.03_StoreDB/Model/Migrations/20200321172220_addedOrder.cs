using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class addedOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders (Sales)",
                columns: new[] { "order_id", "customer_id", "order_date", "order_status", "required_date", "shipped_date", "staff_id", "store_id" },
                values: new object[] { 3, 1, new DateTime(2019, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Processing", new DateTime(2020, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 });

            migrationBuilder.InsertData(
                table: "Orders (Sales)",
                columns: new[] { "order_id", "customer_id", "order_date", "order_status", "required_date", "shipped_date", "staff_id", "store_id" },
                values: new object[] { 4, 2, new DateTime(2018, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Delivered", new DateTime(2020, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders (Sales)",
                keyColumn: "order_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders (Sales)",
                keyColumn: "order_id",
                keyValue: 4);
        }
    }
}
