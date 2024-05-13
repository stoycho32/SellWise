using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWise.Data.Migrations
{
    public partial class SeedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsDeleted", "ManufacturerId", "ProductComment", "ProductName", "ProductPrice", "ProductQuantity" },
                values: new object[,]
                {
                    { 1, false, 1, null, "Davidoff Gold", 6.20m, 10 },
                    { 2, false, 3, null, "Karelia blue 100", 5.50m, 10 },
                    { 3, false, 3, null, "Rothmans DarkBlue 100", 5.20m, 10 },
                    { 4, false, 4, null, "Coca-Cola", 2.20m, 24 },
                    { 5, false, 5, null, "Chio-Chips Paprika", 3.20m, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
