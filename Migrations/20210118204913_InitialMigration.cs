using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KampusStudioProto.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nazioni",
                columns: table => new
                {
                    codice3 = table.Column<string>(type: "varchar(4)", nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    codiceContinente = table.Column<int>(type: "int(11)", nullable: true),
                    codiceArea = table.Column<int>(type: "int(11)", nullable: true),
                    denominazioneIT = table.Column<string>(type: "varchar(36)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    denominazioneEN = table.Column<string>(type: "varchar(32)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    belfiore = table.Column<string>(type: "varchar(4)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    codice2 = table.Column<string>(type: "varchar(4)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    codice3Padre = table.Column<string>(type: "varchar(3)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.codice3);
                });

            migrationBuilder.CreateTable(
                name: "province",
                columns: table => new
                {
                    codiceProvincia = table.Column<int>(type: "int(11)", nullable: false),
                    codiceRegione = table.Column<int>(type: "int(11)", nullable: false),
                    nomeProvincia = table.Column<string>(type: "varchar(28)", nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    siglaProvincia = table.Column<string>(type: "varchar(2)", nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    codiceCapoluogo = table.Column<string>(type: "varchar(4)", nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    CapoluogoCodiceCatastale = table.Column<string>(type: "varchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.codiceProvincia);
                });

            migrationBuilder.CreateTable(
                name: "regioni",
                columns: table => new
                {
                    codiceRegione = table.Column<int>(type: "int(11)", nullable: false, comment: "Codice Regione")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomeRegione = table.Column<string>(type: "varchar(30)", nullable: false, comment: "Nome Regione", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    ripartizioneGeografica = table.Column<int>(type: "int(11)", nullable: false, comment: "Ripartizione geografica"),
                    codiceCapoluogo = table.Column<string>(type: "varchar(4)", nullable: false, comment: "Codice capoluogo di regione", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    CapoluogoCodiceCatastale = table.Column<string>(type: "varchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.codiceRegione);
                },
                comment: "Elenco delle regioni italiane");

            migrationBuilder.CreateTable(
                name: "comuni",
                columns: table => new
                {
                    codiceCatastale = table.Column<string>(type: "varchar(4)", nullable: false, comment: "Codice catastale", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    nomeComune = table.Column<string>(type: "varchar(30)", nullable: false, comment: "Nome comune", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    codiceRegione = table.Column<int>(type: "int(11)", nullable: false, comment: "Regione"),
                    codiceProvincia = table.Column<int>(type: "int(11)", nullable: false, comment: "Provincia"),
                    flagRegione = table.Column<int>(type: "int(1)", nullable: false),
                    flagProvincia = table.Column<int>(type: "int(11)", nullable: false, comment: "Flag provincia"),
                    abitanti = table.Column<int>(type: "int(11)", nullable: false, comment: "Numero abitanti"),
                    prefisso = table.Column<string>(type: "varchar(5)", nullable: false, comment: "Prefisso telefonico", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    cap = table.Column<string>(type: "varchar(5)", nullable: false, comment: "CAP", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    codiceIstat = table.Column<string>(type: "varchar(6)", nullable: false, comment: "Codice Istat", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.codiceCatastale);
                    table.ForeignKey(
                        name: "comuni_ibfk_1",
                        column: x => x.codiceProvincia,
                        principalTable: "province",
                        principalColumn: "codiceProvincia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "comuni_ibfk_2",
                        column: x => x.codiceRegione,
                        principalTable: "regioni",
                        principalColumn: "codiceRegione",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Elenco dei comuni italiani");

            migrationBuilder.CreateIndex(
                name: "codiceProvincia",
                table: "comuni",
                column: "codiceProvincia");

            migrationBuilder.CreateIndex(
                name: "codiceRegione",
                table: "comuni",
                column: "codiceRegione");

            migrationBuilder.CreateIndex(
                name: "CodiceCapoluogo",
                table: "province",
                column: "codiceCapoluogo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "codiceRegione1",
                table: "province",
                column: "codiceRegione");

            migrationBuilder.CreateIndex(
                name: "IX_province_CapoluogoCodiceCatastale",
                table: "province",
                column: "CapoluogoCodiceCatastale");

            migrationBuilder.CreateIndex(
                name: "codiceCapoluogo",
                table: "regioni",
                column: "codiceCapoluogo");

            migrationBuilder.CreateIndex(
                name: "IX_regioni_CapoluogoCodiceCatastale",
                table: "regioni",
                column: "CapoluogoCodiceCatastale");

            migrationBuilder.AddForeignKey(
                name: "FK_province_comuni_CapoluogoCodiceCatastale",
                table: "province",
                column: "CapoluogoCodiceCatastale",
                principalTable: "comuni",
                principalColumn: "codiceCatastale",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "province_ibfk_1",
                table: "province",
                column: "codiceRegione",
                principalTable: "regioni",
                principalColumn: "codiceRegione",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_regioni_comuni_CapoluogoCodiceCatastale",
                table: "regioni",
                column: "CapoluogoCodiceCatastale",
                principalTable: "comuni",
                principalColumn: "codiceCatastale",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "comuni_ibfk_1",
                table: "comuni");

            migrationBuilder.DropForeignKey(
                name: "comuni_ibfk_2",
                table: "comuni");

            migrationBuilder.DropTable(
                name: "nazioni");

            migrationBuilder.DropTable(
                name: "province");

            migrationBuilder.DropTable(
                name: "regioni");

            migrationBuilder.DropTable(
                name: "comuni");
        }
    }
}
