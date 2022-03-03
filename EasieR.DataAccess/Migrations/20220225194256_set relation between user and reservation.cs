using Microsoft.EntityFrameworkCore.Migrations;

namespace EasieR.DataAccess.Migrations
{
    public partial class setrelationbetweenuserandreservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Users_UserId",
                table: "Reservation");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Users_UserId",
                table: "Reservation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Users_UserId",
                table: "Reservation");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Users_UserId",
                table: "Reservation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
