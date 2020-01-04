using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iNeedTickets.Migrations
{
    public partial class tickettypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_events",
                table: "events");

            migrationBuilder.DropColumn(
                name: "price",
                table: "events");

            migrationBuilder.RenameTable(
                name: "events",
                newName: "Events");

            migrationBuilder.RenameColumn(
                name: "photoLink",
                table: "Events",
                newName: "PhotoLink");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Events",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Events",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Events",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Events",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Events",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Events",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TicketTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaName = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    EventRefId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketTypes_Events_EventRefId",
                        column: x => x.EventRefId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketTypes_EventRefId",
                table: "TicketTypes",
                column: "EventRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "events");

            migrationBuilder.RenameColumn(
                name: "PhotoLink",
                table: "events",
                newName: "photoLink");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "events",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "events",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "events",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "events",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "events",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "events",
                newName: "id");

            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "events",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_events",
                table: "events",
                column: "id");
        }
    }
}
