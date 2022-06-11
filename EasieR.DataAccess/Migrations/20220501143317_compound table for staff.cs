using Microsoft.EntityFrameworkCore.Migrations;

namespace EasieR.DataAccess.Migrations
{
    public partial class compoundtableforstaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceStaff_Users_UserId1",
                table: "PlaceStaff");

            migrationBuilder.DropIndex(
                name: "IX_PlaceStaff_UserId1",
                table: "PlaceStaff");

            migrationBuilder.DropColumn(
                name: "PlaceStaffId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "PlaceStaff");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceStaff_UserId",
                table: "PlaceStaff",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceStaff_Users_UserId",
                table: "PlaceStaff",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceStaff_Users_UserId",
                table: "PlaceStaff");

            migrationBuilder.DropIndex(
                name: "IX_PlaceStaff_UserId",
                table: "PlaceStaff");

            migrationBuilder.AddColumn<int>(
                name: "PlaceStaffId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "PlaceStaff",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaceStaff_UserId1",
                table: "PlaceStaff",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceStaff_Users_UserId1",
                table: "PlaceStaff",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
