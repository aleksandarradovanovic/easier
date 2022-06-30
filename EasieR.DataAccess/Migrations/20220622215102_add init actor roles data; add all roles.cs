using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasieR.DataAccess.Migrations
{
    public partial class addinitactorrolesdataaddallroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActorRoles",
                columns: new[] { "ActorId", "RoleId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 3, 24 },
                    { 1, 24 },
                    { 3, 23 },
                    { 2, 23 },
                    { 1, 23 },
                    { 3, 22 },
                    { 1, 25 },
                    { 2, 22 },
                    { 3, 21 },
                    { 1, 21 },
                    { 3, 20 },
                    { 1, 20 },
                    { 3, 19 },
                    { 1, 19 },
                    { 1, 22 },
                    { 3, 18 },
                    { 3, 25 },
                    { 2, 26 },
                    { 1, 31 },
                    { 3, 30 },
                    { 2, 30 },
                    { 1, 30 },
                    { 3, 29 },
                    { 2, 29 },
                    { 1, 26 },
                    { 1, 29 },
                    { 2, 28 },
                    { 1, 28 },
                    { 3, 27 },
                    { 2, 27 },
                    { 1, 27 },
                    { 3, 26 },
                    { 3, 28 },
                    { 2, 18 },
                    { 1, 18 },
                    { 3, 9 },
                    { 1, 9 },
                    { 3, 8 },
                    { 2, 8 },
                    { 1, 8 },
                    { 3, 7 }
                });

            migrationBuilder.InsertData(
                table: "ActorRoles",
                columns: new[] { "ActorId", "RoleId" },
                values: new object[,]
                {
                    { 1, 7 },
                    { 3, 17 },
                    { 3, 6 },
                    { 3, 5 },
                    { 2, 5 },
                    { 1, 5 },
                    { 3, 4 },
                    { 2, 4 },
                    { 1, 4 },
                    { 1, 6 },
                    { 3, 3 },
                    { 1, 10 },
                    { 1, 11 },
                    { 2, 17 },
                    { 1, 17 },
                    { 3, 16 },
                    { 1, 16 },
                    { 3, 15 },
                    { 1, 15 },
                    { 3, 10 },
                    { 3, 14 },
                    { 3, 13 },
                    { 2, 13 },
                    { 1, 13 },
                    { 3, 12 },
                    { 1, 12 },
                    { 3, 11 },
                    { 1, 14 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "Name", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "GET_SEAT_TABLES", false, false },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "GET_PLACE_STAFF", false, false },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "GET_IMAGES", false, false }
                });

            migrationBuilder.InsertData(
                table: "ActorRoles",
                columns: new[] { "ActorId", "RoleId" },
                values: new object[,]
                {
                    { 1, 32 },
                    { 2, 32 },
                    { 3, 32 },
                    { 1, 33 },
                    { 2, 33 },
                    { 3, 33 },
                    { 1, 34 },
                    { 2, 34 },
                    { 3, 34 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 15 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 17 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 18 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 19 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 21 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 22 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 23 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 24 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 25 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 26 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 27 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 28 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 29 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 30 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 31 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 32 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 33 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 34 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 17 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 18 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 22 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 23 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 26 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 27 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 28 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 29 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 30 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 32 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 33 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 34 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 14 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 16 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 17 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 18 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 19 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 20 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 21 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 22 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 23 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 24 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 25 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 26 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 27 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 28 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 29 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 30 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 32 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 33 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 34 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 34);
        }
    }
}
