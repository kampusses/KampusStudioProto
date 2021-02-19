﻿// <auto-generated />
using System;
using KampusStudioProto.Models.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KampusStudioProto.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("KampusStudioProto.Models.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Cognome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("KampusStudioProto.Models.Entities.Comune", b =>
                {
                    b.Property<string>("CodiceCatastale")
                        .HasColumnType("varchar(4)")
                        .HasColumnName("codiceCatastale")
                        .HasComment("Codice catastale")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<int>("Abitanti")
                        .HasColumnType("int(11)")
                        .HasColumnName("abitanti")
                        .HasComment("Numero abitanti");

                    b.Property<string>("Cap")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasColumnName("cap")
                        .HasComment("CAP")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("CodiceIstat")
                        .IsRequired()
                        .HasColumnType("varchar(6)")
                        .HasColumnName("codiceIstat")
                        .HasComment("Codice Istat")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<int>("CodiceProvincia")
                        .HasColumnType("int(11)")
                        .HasColumnName("codiceProvincia")
                        .HasComment("Provincia");

                    b.Property<int>("CodiceRegione")
                        .HasColumnType("int(11)")
                        .HasColumnName("codiceRegione")
                        .HasComment("Regione");

                    b.Property<int>("FlagProvincia")
                        .HasColumnType("int(11)")
                        .HasColumnName("flagProvincia")
                        .HasComment("Flag provincia");

                    b.Property<int>("FlagRegione")
                        .HasColumnType("int(1)")
                        .HasColumnName("flagRegione");

                    b.Property<string>("NomeComune")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("nomeComune")
                        .HasComment("Nome comune")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Prefisso")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasColumnName("prefisso")
                        .HasComment("Prefisso telefonico")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.HasKey("CodiceCatastale")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CodiceProvincia" }, "codiceProvincia");

                    b.HasIndex(new[] { "CodiceRegione" }, "codiceRegione");

                    b.ToTable("comuni");

                    b
                        .HasComment("Elenco dei comuni italiani");
                });

            modelBuilder.Entity("KampusStudioProto.Models.Entities.Ente", b =>
                {
                    b.Property<string>("CodiceCatastale")
                        .HasColumnType("varchar(4)")
                        .HasColumnName("codiceCatastale")
                        .HasComment("Codice catastale")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<int>("Civico")
                        .HasColumnType("int(11)")
                        .HasColumnName("civico")
                        .HasComment("Civico");

                    b.Property<string>("CodiceFiscale")
                        .HasColumnType("varchar(11)")
                        .HasColumnName("codiceFiscale")
                        .HasComment("Codice fiscale")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("CognomeResponsabile")
                        .HasColumnType("varchar(40)")
                        .HasColumnName("cognomeResponsabile")
                        .HasComment("Cognome responsabile")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(60)")
                        .HasColumnName("email")
                        .HasComment("Email")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Indirizzo")
                        .HasColumnType("varchar(60)")
                        .HasColumnName("indirizzo")
                        .HasComment("CIndirizzo")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Lettera")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("lettera")
                        .HasComment("Lettera")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Localita")
                        .HasColumnType("varchar(40)")
                        .HasColumnName("localita")
                        .HasComment("Località")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("NomeResponsabile")
                        .HasColumnType("varchar(40)")
                        .HasColumnName("nomeResponsabile")
                        .HasComment("Nome responsabile")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("PartitaIva")
                        .HasColumnType("varchar(11)")
                        .HasColumnName("partitaIva")
                        .HasComment("Partita IVA")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Pec")
                        .HasColumnType("varchar(60)")
                        .HasColumnName("pec")
                        .HasComment("Pec")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Telefono")
                        .HasColumnType("varchar(15)")
                        .HasColumnName("telefono")
                        .HasComment("Telefono")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("TitoloResponsabile")
                        .HasColumnType("varchar(30)")
                        .HasColumnName("titoloResponsabile")
                        .HasComment("Titolo responsabile")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Toponimo")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("toponimo")
                        .HasComment("Toponimo")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.HasKey("CodiceCatastale")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CodiceCatastale" }, "codiceCatastale");

                    b.ToTable("ente");

                    b
                        .HasComment("Dati ente in gestione");
                });

            modelBuilder.Entity("KampusStudioProto.Models.Entities.Nazione", b =>
                {
                    b.Property<string>("Codice3")
                        .HasColumnType("varchar(4)")
                        .HasColumnName("codice3")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Belfiore")
                        .HasColumnType("varchar(4)")
                        .HasColumnName("belfiore")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Codice2")
                        .HasColumnType("varchar(4)")
                        .HasColumnName("codice2")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Codice3Padre")
                        .HasColumnType("varchar(3)")
                        .HasColumnName("codice3Padre")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<int>("CodiceArea")
                        .HasColumnType("int(11)")
                        .HasColumnName("codiceArea");

                    b.Property<int>("CodiceContinente")
                        .HasColumnType("int(11)")
                        .HasColumnName("codiceContinente");

                    b.Property<string>("DenominazioneEn")
                        .HasColumnType("varchar(32)")
                        .HasColumnName("denominazioneEN")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("DenominazioneIt")
                        .HasColumnType("varchar(36)")
                        .HasColumnName("denominazioneIT")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.HasKey("Codice3")
                        .HasName("PRIMARY");

                    b.ToTable("nazioni");
                });

            modelBuilder.Entity("KampusStudioProto.Models.Entities.Provincia", b =>
                {
                    b.Property<int>("CodiceProvincia")
                        .HasColumnType("int(11)")
                        .HasColumnName("codiceProvincia");

                    b.Property<string>("CapoluogoCodiceCatastale")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("CodiceCapoluogo")
                        .IsRequired()
                        .HasColumnType("varchar(4)")
                        .HasColumnName("codiceCapoluogo")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<int>("CodiceRegione")
                        .HasColumnType("int(11)")
                        .HasColumnName("codiceRegione");

                    b.Property<string>("NomeProvincia")
                        .IsRequired()
                        .HasColumnType("varchar(28)")
                        .HasColumnName("nomeProvincia")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("SiglaProvincia")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("siglaProvincia")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.HasKey("CodiceProvincia")
                        .HasName("PRIMARY");

                    b.HasIndex("CapoluogoCodiceCatastale");

                    b.HasIndex(new[] { "CodiceCapoluogo" }, "CodiceCapoluogo")
                        .IsUnique();

                    b.HasIndex(new[] { "CodiceRegione" }, "codiceRegione")
                        .HasDatabaseName("codiceRegione1");

                    b.ToTable("province");
                });

            modelBuilder.Entity("KampusStudioProto.Models.Entities.Regione", b =>
                {
                    b.Property<int>("CodiceRegione")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("codiceRegione")
                        .HasComment("Codice Regione");

                    b.Property<string>("CapoluogoCodiceCatastale")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("CodiceCapoluogo")
                        .IsRequired()
                        .HasColumnType("varchar(4)")
                        .HasColumnName("codiceCapoluogo")
                        .HasComment("Codice capoluogo di regione")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("NomeRegione")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("nomeRegione")
                        .HasComment("Nome Regione")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<int>("RipartizioneGeografica")
                        .HasColumnType("int(11)")
                        .HasColumnName("ripartizioneGeografica")
                        .HasComment("Ripartizione geografica");

                    b.HasKey("CodiceRegione")
                        .HasName("PRIMARY");

                    b.HasIndex("CapoluogoCodiceCatastale");

                    b.HasIndex(new[] { "CodiceCapoluogo" }, "codiceCapoluogo");

                    b.ToTable("regioni");

                    b
                        .HasComment("Elenco delle regioni italiane");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("KampusStudioProto.Models.Entities.Comune", b =>
                {
                    b.HasOne("KampusStudioProto.Models.Entities.Provincia", "Provincia")
                        .WithMany("Comuni")
                        .HasForeignKey("CodiceProvincia")
                        .HasConstraintName("comuni_ibfk_1")
                        .IsRequired();

                    b.HasOne("KampusStudioProto.Models.Entities.Regione", "Regione")
                        .WithMany("Comuni")
                        .HasForeignKey("CodiceRegione")
                        .HasConstraintName("comuni_ibfk_2")
                        .IsRequired();

                    b.Navigation("Provincia");

                    b.Navigation("Regione");
                });

            modelBuilder.Entity("KampusStudioProto.Models.Entities.Ente", b =>
                {
                    b.HasOne("KampusStudioProto.Models.Entities.Comune", "Comune")
                        .WithOne("Ente")
                        .HasForeignKey("KampusStudioProto.Models.Entities.Ente", "CodiceCatastale")
                        .HasConstraintName("ente_ibfk_1")
                        .IsRequired();

                    b.Navigation("Comune");
                });

            modelBuilder.Entity("KampusStudioProto.Models.Entities.Provincia", b =>
                {
                    b.HasOne("KampusStudioProto.Models.Entities.Comune", "Capoluogo")
                        .WithMany()
                        .HasForeignKey("CapoluogoCodiceCatastale");

                    b.HasOne("KampusStudioProto.Models.Entities.Regione", "Regione")
                        .WithMany("Province")
                        .HasForeignKey("CodiceRegione")
                        .HasConstraintName("province_ibfk_1")
                        .IsRequired();

                    b.Navigation("Capoluogo");

                    b.Navigation("Regione");
                });

            modelBuilder.Entity("KampusStudioProto.Models.Entities.Regione", b =>
                {
                    b.HasOne("KampusStudioProto.Models.Entities.Comune", "Capoluogo")
                        .WithMany()
                        .HasForeignKey("CapoluogoCodiceCatastale");

                    b.Navigation("Capoluogo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("KampusStudioProto.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("KampusStudioProto.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KampusStudioProto.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("KampusStudioProto.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KampusStudioProto.Models.Entities.Comune", b =>
                {
                    b.Navigation("Ente");
                });

            modelBuilder.Entity("KampusStudioProto.Models.Entities.Provincia", b =>
                {
                    b.Navigation("Comuni");
                });

            modelBuilder.Entity("KampusStudioProto.Models.Entities.Regione", b =>
                {
                    b.Navigation("Comuni");

                    b.Navigation("Province");
                });
#pragma warning restore 612, 618
        }
    }
}
