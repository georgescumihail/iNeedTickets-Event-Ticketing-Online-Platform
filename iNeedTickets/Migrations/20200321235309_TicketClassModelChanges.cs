using Microsoft.EntityFrameworkCore.Migrations;

namespace iNeedTickets.Migrations
{
    public partial class TicketClassModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "TicketTypes",
                newName: "TicketsRemaining");

            migrationBuilder.AddColumn<int>(
                name: "TicketsCapacity",
                table: "TicketTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketsCapacity",
                table: "TicketTypes");

            migrationBuilder.RenameColumn(
                name: "TicketsRemaining",
                table: "TicketTypes",
                newName: "Capacity");
        }
    }
}
