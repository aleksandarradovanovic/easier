using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasieR.DataAccess.Migrations
{
    public partial class addinitadminuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActorId", "CreatedAt", "DateOfBirth", "DeletedAt", "Email", "FirstName", "LastName", "ModifiedAt", "Password", "PhoneNumber", "Status", "UserName", "isActive", "isDeleted" },
                values: new object[] { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@root", "admin", "admin", null, "admin123", null, null, "admin", false, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
