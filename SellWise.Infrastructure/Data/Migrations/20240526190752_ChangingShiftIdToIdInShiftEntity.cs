using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWise.Data.Migrations
{
    public partial class ChangingShiftIdToIdInShiftEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShiftId",
                table: "Shifts",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Shifts",
                newName: "ShiftId");
        }
    }
}
