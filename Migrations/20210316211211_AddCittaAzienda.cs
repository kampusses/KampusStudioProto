using Microsoft.EntityFrameworkCore.Migrations;

namespace KampusStudioProto.Migrations
{
    public partial class AddCittaAzienda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cittaAzienda",
                table: "azienda",
                type: "varchar(4)",
                nullable: true,
                comment: "Città azienda",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cittaAzienda",
                table: "azienda");
        }
    }
}
