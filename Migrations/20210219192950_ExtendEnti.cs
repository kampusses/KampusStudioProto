using Microsoft.EntityFrameworkCore.Migrations;

namespace KampusStudioProto.Migrations
{
    public partial class ExtendEnti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "pec",
                table: "ente",
                type: "varchar(60)",
                nullable: true,
                comment: "Pec",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true,
                oldComment: "Pec",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "nomeResponsabile",
                table: "ente",
                type: "varchar(40)",
                nullable: true,
                comment: "Nome responsabile",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true,
                oldComment: "Nome responsabile",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "localita",
                table: "ente",
                type: "varchar(40)",
                nullable: true,
                comment: "Località",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true,
                oldComment: "Località",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "lettera",
                table: "ente",
                type: "varchar(10)",
                nullable: true,
                comment: "Lettera",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldNullable: true,
                oldComment: "Lettera",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "indirizzo",
                table: "ente",
                type: "varchar(60)",
                nullable: true,
                comment: "CIndirizzo",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true,
                oldComment: "CIndirizzo",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "ente",
                type: "varchar(60)",
                nullable: true,
                comment: "Email",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true,
                oldComment: "Email",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "cognomeResponsabile",
                table: "ente",
                type: "varchar(40)",
                nullable: true,
                comment: "Cognome responsabile",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true,
                oldComment: "Cognome responsabile",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "codiceFiscale",
                table: "ente",
                type: "varchar(11)",
                nullable: true,
                comment: "Codice fiscale",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldNullable: true,
                oldComment: "Codice fiscale",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "pec",
                table: "ente",
                type: "varchar(30)",
                nullable: true,
                comment: "Pec",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldNullable: true,
                oldComment: "Pec",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "nomeResponsabile",
                table: "ente",
                type: "varchar(30)",
                nullable: true,
                comment: "Nome responsabile",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true,
                oldComment: "Nome responsabile",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "localita",
                table: "ente",
                type: "varchar(30)",
                nullable: true,
                comment: "Località",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true,
                oldComment: "Località",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "lettera",
                table: "ente",
                type: "varchar(5)",
                nullable: true,
                comment: "Lettera",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true,
                oldComment: "Lettera",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "indirizzo",
                table: "ente",
                type: "varchar(30)",
                nullable: true,
                comment: "CIndirizzo",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldNullable: true,
                oldComment: "CIndirizzo",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "ente",
                type: "varchar(30)",
                nullable: true,
                comment: "Email",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldNullable: true,
                oldComment: "Email",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "cognomeResponsabile",
                table: "ente",
                type: "varchar(30)",
                nullable: true,
                comment: "Cognome responsabile",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true,
                oldComment: "Cognome responsabile",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "codiceFiscale",
                table: "ente",
                type: "varchar(16)",
                nullable: true,
                comment: "Codice fiscale",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldNullable: true,
                oldComment: "Codice fiscale",
                oldCollation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1");
        }
    }
}
