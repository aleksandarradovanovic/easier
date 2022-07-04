using Microsoft.EntityFrameworkCore.Migrations;

namespace EasieR.DataAccess.Migrations
{
    public partial class reservationtypeseattablestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeatTableReservationType",
                columns: table => new
                {
                    SeatTableId = table.Column<int>(type: "int", nullable: false),
                    ReservationTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTableReservationType", x => new { x.ReservationTypeId, x.SeatTableId });
                    table.ForeignKey(
                        name: "FK_SeatTableReservationType_ReservationType_ReservationTypeId",
                        column: x => x.ReservationTypeId,
                        principalTable: "ReservationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeatTableReservationType_SeatTable_SeatTableId",
                        column: x => x.SeatTableId,
                        principalTable: "SeatTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatTableReservationType_SeatTableId",
                table: "SeatTableReservationType",
                column: "SeatTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatTableReservationType");
        }
    }
}
