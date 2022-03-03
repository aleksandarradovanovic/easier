using Microsoft.EntityFrameworkCore.Migrations;

namespace EasieR.DataAccess.Migrations
{
    public partial class setuseridinreservationtableasint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Users_UserId1",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_UserId1",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Users_UserId",
                table: "Reservation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Users_UserId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId1",
                table: "Reservation",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Users_UserId1",
                table: "Reservation",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
