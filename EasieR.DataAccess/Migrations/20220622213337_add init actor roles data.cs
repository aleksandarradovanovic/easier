using Microsoft.EntityFrameworkCore.Migrations;

namespace EasieR.DataAccess.Migrations
{
    public partial class addinitactorrolesdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActorRoles",
                columns: new[] { "ActorId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ActorRoles",
                keyColumns: new[] { "ActorId", "RoleId" },
                keyValues: new object[] { 3, 2 });
        }
    }
}
