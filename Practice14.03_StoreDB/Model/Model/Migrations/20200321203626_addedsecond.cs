using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class addedsecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders (Sales)",
                keyColumn: "order_id",
                keyValue: 1,
                columns: new[] { "order_date", "required_date", "shipped_date" },
                values: new object[] { new DateTime(2019, 12, 1, 13, 56, 30, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 12, 23, 20, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 19, 6, 10, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders (Sales)",
                keyColumn: "order_id",
                keyValue: 2,
                columns: new[] { "order_date", "required_date", "shipped_date" },
                values: new object[] { new DateTime(2020, 3, 1, 13, 56, 30, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 1, 15, 20, 30, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 19, 4, 20, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders (Sales)",
                keyColumn: "order_id",
                keyValue: 3,
                columns: new[] { "order_date", "required_date", "shipped_date" },
                values: new object[] { new DateTime(2019, 1, 3, 13, 56, 30, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 29, 3, 10, 30, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 2, 13, 56, 30, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders (Sales)",
                keyColumn: "order_id",
                keyValue: 4,
                columns: new[] { "order_date", "required_date", "shipped_date" },
                values: new object[] { new DateTime(2018, 3, 3, 18, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 13, 13, 12, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 29, 11, 45, 30, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders (Sales)",
                keyColumn: "order_id",
                keyValue: 1,
                columns: new[] { "order_date", "required_date", "shipped_date" },
                values: new object[] { new DateTime(2019, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders (Sales)",
                keyColumn: "order_id",
                keyValue: 2,
                columns: new[] { "order_date", "required_date", "shipped_date" },
                values: new object[] { new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders (Sales)",
                keyColumn: "order_id",
                keyValue: 3,
                columns: new[] { "order_date", "required_date", "shipped_date" },
                values: new object[] { new DateTime(2019, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Orders (Sales)",
                keyColumn: "order_id",
                keyValue: 4,
                columns: new[] { "order_date", "required_date", "shipped_date" },
                values: new object[] { new DateTime(2018, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
