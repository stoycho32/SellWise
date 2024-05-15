using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWise.Data.Migrations
{
    public partial class AddingFinalizationPropertiesToSaleAndShiftEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShiftEndTime",
                table: "Shifts",
                newName: "FinalizationDateTime");

            migrationBuilder.RenameColumn(
                name: "IsShiftFinished",
                table: "Shifts",
                newName: "IsFinalized");

            migrationBuilder.RenameColumn(
                name: "SaleDateTime",
                table: "Sales",
                newName: "SaleStartDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinalizationDateTime",
                table: "Sales",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinalized",
                table: "Sales",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalizationDateTime",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "IsFinalized",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "IsFinalized",
                table: "Shifts",
                newName: "IsShiftFinished");

            migrationBuilder.RenameColumn(
                name: "FinalizationDateTime",
                table: "Shifts",
                newName: "ShiftEndTime");

            migrationBuilder.RenameColumn(
                name: "SaleStartDateTime",
                table: "Sales",
                newName: "SaleDateTime");
        }
    }
}
