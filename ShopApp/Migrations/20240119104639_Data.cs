using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopApp.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Advertisements",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 800);

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 1200);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Advertisements",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 800m);

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 1200m);
        }
    }
}
