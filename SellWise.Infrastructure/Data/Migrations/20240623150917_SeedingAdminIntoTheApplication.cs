using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellWise.Data.Migrations
{
    public partial class SeedingAdminIntoTheApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDisabled", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d3d412e3-bdfd-49fc-89e5-7c53a3075673", 0, "31a8cc9b-c94e-4c3f-97b5-fa90b8e736e1", "admin@mail.com", false, "Stoycho", false, "Karadaliev", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAELNHRtyT3FfCQc0MkstkZtcWn7aYBJLqOWE/9+RIxfg6DKw3YdDFrlCn2ndxwfC34w==", null, false, "fb164aec-d8ec-4800-8afc-513c4f4b3557", false, "admin@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3d412e3-bdfd-49fc-89e5-7c53a3075673");
        }
    }
}
