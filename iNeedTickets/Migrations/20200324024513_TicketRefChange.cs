using Microsoft.EntityFrameworkCore.Migrations;

namespace iNeedTickets.Migrations
{
    public partial class TicketRefChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventClassRef",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "TicketClassRefId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketClassRefId",
                table: "Tickets",
                column: "TicketClassRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketTypes_TicketClassRefId",
                table: "Tickets",
                column: "TicketClassRefId",
                principalTable: "TicketTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketTypes_TicketClassRefId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketClassRefId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketClassRefId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "EventClassRef",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);
        }
    }
}
