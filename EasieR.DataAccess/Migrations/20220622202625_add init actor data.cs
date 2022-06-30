using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasieR.DataAccess.Migrations
{
    public partial class addinitactordata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "Name", "isActive", "isDeleted" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "ADMIN", false, false });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "Name", "isActive", "isDeleted" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PUBLIC", false, false });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "Name", "isActive", "isDeleted" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PLACE", false, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
