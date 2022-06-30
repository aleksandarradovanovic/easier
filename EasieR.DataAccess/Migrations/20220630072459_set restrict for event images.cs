using Microsoft.EntityFrameworkCore.Migrations;

namespace EasieR.DataAccess.Migrations
{
    public partial class setrestrictforeventimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Event_EventId",
                table: "Images");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Event_EventId",
                table: "Images",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Event_EventId",
                table: "Images");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Event_EventId",
                table: "Images",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
