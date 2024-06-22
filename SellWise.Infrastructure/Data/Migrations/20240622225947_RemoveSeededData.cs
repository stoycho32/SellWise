using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWise.Data.Migrations
{
    public partial class RemoveSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufacturers_ManufacturerId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ManufacturerAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ManufacturerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ManufacturerSerialNumber = table.Column<int>(type: "int", nullable: false, comment: "Manufacturer EIK")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "IsDeleted", "ManufacturerAddress", "ManufacturerEmail", "ManufacturerName", "ManufacturerSerialNumber" },
                values: new object[,]
                {
                    { 1, false, "ul. Rakovska No 6, bl. 56, vh. A", "bgtabaco@abv.bg", "BGTabaco LTD", 1234567890 },
                    { 2, false, "ul. Rakovska No 6, bl. 56, vh. A", "marlborobg@abv.bg", "MarlboroBG LTD", 1234567890 },
                    { 3, false, "ul. Rakovska No 6, bl. 56, vh. A", "rothmansbg@abv.bg", "RothmansBG LTD", 1234567890 },
                    { 4, false, "ul. Rakovska No 6, bl. 56, vh. A", "drinksbg@abv.bg", "DrinksBG", 1234567890 },
                    { 5, false, "ul. Rakovska No 6, bl. 56, vh. A", "chiochipsbg@abv.bg", "ChioBG LTD", 1234567890 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ManufacturerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ManufacturerId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ManufacturerId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ManufacturerId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ManufacturerId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufacturers_ManufacturerId",
                table: "Products",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
