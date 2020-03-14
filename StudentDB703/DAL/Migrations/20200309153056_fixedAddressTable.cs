using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class fixedAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StudentId",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Address",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_StudentId",
                table: "Address",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StudentId",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Address",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Address_StudentId",
                table: "Address",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
