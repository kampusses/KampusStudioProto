using Microsoft.EntityFrameworkCore.Migrations;

namespace KampusStudioProto.Migrations
{
    public partial class AddFaxEnte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fax",
                table: "ente",
                type: "varchar(15)",
                nullable: true,
                comment: "Fax",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fax",
                table: "ente");
        }
    }
}
