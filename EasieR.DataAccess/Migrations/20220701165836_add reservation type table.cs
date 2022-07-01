using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasieR.DataAccess.Migrations
{
    public partial class addreservationtypetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Event_EventId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Place_PlaceId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_EventId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "PlaceId",
                table: "Reservation",
                newName: "ReservationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_PlaceId",
                table: "Reservation",
                newName: "IX_Reservation_ReservationTypeId");

            migrationBuilder.AddColumn<int>(
                name: "ReservationTypeId",
                table: "SeatTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReservationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    MaxNumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationType_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatTable_ReservationTypeId",
                table: "SeatTable",
                column: "ReservationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationType_EventId",
                table: "ReservationType",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ReservationType_ReservationTypeId",
                table: "Reservation",
                column: "ReservationTypeId",
                principalTable: "ReservationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatTable_ReservationType_ReservationTypeId",
                table: "SeatTable",
                column: "ReservationTypeId",
                principalTable: "ReservationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ReservationType_ReservationTypeId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatTable_ReservationType_ReservationTypeId",
                table: "SeatTable");

            migrationBuilder.DropTable(
                name: "ReservationType");

            migrationBuilder.DropIndex(
                name: "IX_SeatTable_ReservationTypeId",
                table: "SeatTable");

            migrationBuilder.DropColumn(
                name: "ReservationTypeId",
                table: "SeatTable");

            migrationBuilder.RenameColumn(
                name: "ReservationTypeId",
                table: "Reservation",
                newName: "PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_ReservationTypeId",
                table: "Reservation",
                newName: "IX_Reservation_PlaceId");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Reservation",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "Reservation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Reservation",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_EventId",
                table: "Reservation",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Event_EventId",
                table: "Reservation",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Place_PlaceId",
                table: "Reservation",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
