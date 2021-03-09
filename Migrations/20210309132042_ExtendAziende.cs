using Microsoft.EntityFrameworkCore.Migrations;

namespace KampusStudioProto.Migrations
{
    public partial class ExtendAziende : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "civicoAgenzia",
                table: "azienda",
                type: "int(11)",
                nullable: false,
                defaultValue: 0,
                comment: "Civico Agenzia");

            migrationBuilder.AddColumn<int>(
                name: "civicoAzienda",
                table: "azienda",
                type: "int(11)",
                nullable: false,
                defaultValue: 0,
                comment: "Civico Azienda");

            migrationBuilder.AddColumn<string>(
                name: "codiceFiscaleAzienda",
                table: "azienda",
                type: "varchar(11)",
                nullable: true,
                comment: "Codice fiscale azienda",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "emailAgenzia",
                table: "azienda",
                type: "varchar(60)",
                nullable: true,
                comment: "Email agenzia",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "emailAzienda",
                table: "azienda",
                type: "varchar(60)",
                nullable: true,
                comment: "Email azienda",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "faxAgenzia",
                table: "azienda",
                type: "varchar(15)",
                nullable: true,
                comment: "Fax agenzia",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "faxAzienda",
                table: "azienda",
                type: "varchar(15)",
                nullable: true,
                comment: "Fax azienda",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "indirizzoAgenzia",
                table: "azienda",
                type: "varchar(40)",
                nullable: true,
                comment: "Indirizzo agenzia",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "indirizzoAzienda",
                table: "azienda",
                type: "varchar(40)",
                nullable: true,
                comment: "Indirizzo azienda",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "letteraAgenzia",
                table: "azienda",
                type: "varchar(10)",
                nullable: true,
                comment: "Lettera agenzia",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "letteraAzienda",
                table: "azienda",
                type: "varchar(10)",
                nullable: true,
                comment: "Lettera azienda",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "localitaAgenzia",
                table: "azienda",
                type: "varchar(40)",
                nullable: true,
                comment: "Località agenzia",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "localitaAzienda",
                table: "azienda",
                type: "varchar(40)",
                nullable: true,
                comment: "Località azienda",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "partitaIvaAzienda",
                table: "azienda",
                type: "varchar(11)",
                nullable: true,
                comment: "Partita IVA azienda",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "pecAgenzia",
                table: "azienda",
                type: "varchar(60)",
                nullable: true,
                comment: "Pec agenzia",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "pecAzienda",
                table: "azienda",
                type: "varchar(60)",
                nullable: true,
                comment: "Pec azienda",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "telefonoAgenzia",
                table: "azienda",
                type: "varchar(15)",
                nullable: true,
                comment: "Telefono agenzia",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "telefonoAzienda",
                table: "azienda",
                type: "varchar(15)",
                nullable: true,
                comment: "Telefono azienda",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "toponimoAgenzia",
                table: "azienda",
                type: "varchar(20)",
                nullable: true,
                comment: "Toponimo agenzia",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "toponimoAzienda",
                table: "azienda",
                type: "varchar(20)",
                nullable: true,
                comment: "Toponimo azienda",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "civicoAgenzia",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "civicoAzienda",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "codiceFiscaleAzienda",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "emailAgenzia",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "emailAzienda",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "faxAgenzia",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "faxAzienda",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "indirizzoAgenzia",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "indirizzoAzienda",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "letteraAgenzia",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "letteraAzienda",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "localitaAgenzia",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "localitaAzienda",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "partitaIvaAzienda",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "pecAgenzia",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "pecAzienda",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "telefonoAgenzia",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "telefonoAzienda",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "toponimoAgenzia",
                table: "azienda");

            migrationBuilder.DropColumn(
                name: "toponimoAzienda",
                table: "azienda");
        }
    }
}
