using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWise.Data.Migrations
{
    public partial class AddingFinalPriceInOrderToCalculateTheTotalShiftAmountThatIsSold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FinalPrice",
                table: "Sales",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "Sales");
        }
    }
}
