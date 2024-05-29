using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWise.Data.Migrations
{
    public partial class AddingIsDiscountAppliedBoolToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDiscountAplied",
                table: "Sales",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDiscountAplied",
                table: "Sales");
        }
    }
}
