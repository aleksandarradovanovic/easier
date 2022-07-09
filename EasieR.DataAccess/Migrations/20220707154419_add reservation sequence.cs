using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasieR.DataAccess.Migrations
{
    public partial class addreservationsequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationSequenceId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReservationSequence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrivateKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationSequence", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ReservationSequenceId",
                table: "Reservation",
                column: "ReservationSequenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ReservationSequence_ReservationSequenceId",
                table: "Reservation",
                column: "ReservationSequenceId",
                principalTable: "ReservationSequence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ReservationSequence_ReservationSequenceId",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "ReservationSequence");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_ReservationSequenceId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "ReservationSequenceId",
                table: "Reservation");
        }
    }
}
