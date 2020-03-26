using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iNeedTickets.Migrations
{
    public partial class ExtendedTicketModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserRef",
                table: "Tickets",
                newName: "UserRefId");

            migrationBuilder.AlterColumn<string>(
                name: "UserRefId",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EncryptionPath",
                table: "Tickets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserRefId",
                table: "Tickets",
                column: "UserRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_UserRefId",
                table: "Tickets",
                column: "UserRefId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_UserRefId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserRefId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EncryptionPath",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "UserRefId",
                table: "Tickets",
                newName: "UserRef");

            migrationBuilder.AlterColumn<string>(
                name: "UserRef",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
