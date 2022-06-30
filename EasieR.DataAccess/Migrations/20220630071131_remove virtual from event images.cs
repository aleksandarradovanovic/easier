using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasieR.DataAccess.Migrations
{
    public partial class removevirtualfromeventimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "Name", "isActive", "isDeleted" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PUBLIC_UNAUTORIZED", false, false });

            migrationBuilder.InsertData(
                table: "ActorRoles",
                columns: new[] { "ActorId", "RoleId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 4, 17 },
                    { 4, 18 },
                    { 4, 22 },
                    { 4, 23 },
                    { 4, 26 },
                    { 4, 27 },
                    { 4, 29 },
                    { 4, 30 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 4, 17 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 4, 18 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 4, 22 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 4, 23 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 4, 26 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 4, 27 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 4, 29 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 4, 30 });

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
