using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopApp.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Advertisements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisementAttribute",
                columns: table => new
                {
                    AdvertisementsId = table.Column<int>(type: "int", nullable: false),
                    AttributesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementAttribute", x => new { x.AdvertisementsId, x.AttributesId });
                    table.ForeignKey(
                        name: "FK_AdvertisementAttribute_Advertisements_AdvertisementsId",
                        column: x => x.AdvertisementsId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertisementAttribute_Attributes_AttributesId",
                        column: x => x.AttributesId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "LocationId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "LocationId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_LocationId",
                table: "Advertisements",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementAttribute_AttributesId",
                table: "AdvertisementAttribute",
                column: "AttributesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Locations_LocationId",
                table: "Advertisements",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Locations_LocationId",
                table: "Advertisements");

            migrationBuilder.DropTable(
                name: "AdvertisementAttribute");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_LocationId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Advertisements");
        }
    }
}
