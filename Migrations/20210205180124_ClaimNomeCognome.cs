using Microsoft.EntityFrameworkCore.Migrations;

namespace KampusStudioProto.Migrations
{
    public partial class ClaimNomeCognome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "Nome");

            migrationBuilder.AddColumn<string>(
                name: "Cognome",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cognome",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "AspNetUsers",
                newName: "FullName");
        }
    }
}
