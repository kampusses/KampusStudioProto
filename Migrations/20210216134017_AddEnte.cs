using Microsoft.EntityFrameworkCore.Migrations;

namespace KampusStudioProto.Migrations
{
    public partial class AddEnte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "codiceContinente",
                table: "nazioni",
                type: "int(11)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "codiceArea",
                table: "nazioni",
                type: "int(11)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ente",
                columns: table => new
                {
                    codiceCatastale = table.Column<string>(type: "varchar(4)", nullable: false, comment: "Codice catastale", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    partitaIva = table.Column<string>(type: "varchar(11)", nullable: true, comment: "Partita IVA", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    codiceFiscale = table.Column<string>(type: "varchar(16)", nullable: true, comment: "Codice fiscale", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    toponimo = table.Column<string>(type: "varchar(20)", nullable: true, comment: "Toponimo", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    indirizzo = table.Column<string>(type: "varchar(30)", nullable: true, comment: "CIndirizzo", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    civico = table.Column<int>(type: "int(11)", nullable: false, comment: "Civico"),
                    lettera = table.Column<string>(type: "varchar(5)", nullable: true, comment: "Lettera", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    localita = table.Column<string>(type: "varchar(30)", nullable: true, comment: "Località", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    telefono = table.Column<string>(type: "varchar(15)", nullable: true, comment: "Telefono", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    email = table.Column<string>(type: "varchar(30)", nullable: true, comment: "Email", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    pec = table.Column<string>(type: "varchar(30)", nullable: true, comment: "Pec", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    titoloResponsabile = table.Column<string>(type: "varchar(30)", nullable: true, comment: "Titolo responsabile", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    cognomeResponsabile = table.Column<string>(type: "varchar(30)", nullable: true, comment: "Cognome responsabile", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    nomeResponsabile = table.Column<string>(type: "varchar(30)", nullable: true, comment: "Nome responsabile", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.codiceCatastale);
                    table.ForeignKey(
                        name: "ente_ibfk_1",
                        column: x => x.codiceCatastale,
                        principalTable: "comuni",
                        principalColumn: "codiceCatastale",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Dati ente in gestione");

            migrationBuilder.CreateIndex(
                name: "codiceCatastale",
                table: "ente",
                column: "codiceCatastale");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ente");

            migrationBuilder.AlterColumn<int>(
                name: "codiceContinente",
                table: "nazioni",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<int>(
                name: "codiceArea",
                table: "nazioni",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");
        }
    }
}
