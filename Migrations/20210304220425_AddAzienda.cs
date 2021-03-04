using Microsoft.EntityFrameworkCore.Migrations;

namespace KampusStudioProto.Migrations
{
    public partial class AddAzienda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "azienda",
                columns: table => new
                {
                    nomeAzienda = table.Column<string>(type: "varchar(40)", nullable: false, comment: "Nome azienda", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                },
                comment: "Azienda concessionaria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "azienda");
        }
    }
}
