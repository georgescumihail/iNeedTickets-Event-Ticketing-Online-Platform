using Microsoft.EntityFrameworkCore.Migrations;

namespace iNeedTickets.Migrations
{
    public partial class TicketChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserRef",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserRef",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
