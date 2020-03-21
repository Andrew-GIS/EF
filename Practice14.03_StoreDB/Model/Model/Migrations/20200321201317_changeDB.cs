using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class changeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Staffs (Sales)",
                keyColumn: "staff_id",
                keyValue: 1,
                column: "active",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Staffs (Sales)",
                keyColumn: "staff_id",
                keyValue: 1,
                column: "active",
                value: true);
        }
    }
}
