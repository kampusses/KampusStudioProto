﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using KampusStudioProto.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

#nullable disable

namespace KampusStudioProto.Models.Services.Infrastructure
{
    public partial class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comune> Comuni { get; set; }
        public virtual DbSet<Nazione> Nazioni { get; set; }
        public virtual DbSet<Provincia> Province { get; set; }
        public virtual DbSet<Regione> Regioni { get; set; }
        public virtual DbSet<Ente> Enti { get; set; }
        public virtual DbSet<Azienda> Aziende { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //ereditiamo il mapping dell'IdentityDbContext
            modelBuilder.Entity<Comune>(entity =>
            {
                entity.HasKey(e => e.CodiceCatastale)
                    .HasName("PRIMARY");

                entity.ToTable("comuni");

                entity.HasComment("Elenco dei comuni italiani");

                entity.HasIndex(e => e.CodiceProvincia, "codiceProvincia");

                entity.HasIndex(e => e.CodiceRegione, "codiceRegione");

                entity.Property(e => e.CodiceCatastale)
                    .HasColumnType("varchar(4)")
                    .HasColumnName("codiceCatastale")
                    .HasComment("Codice catastale")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Abitanti)
                    .HasColumnType("int(11)")
                    .HasColumnName("abitanti")
                    .HasComment("Numero abitanti");

                entity.Property(e => e.Cap)
                    .IsRequired()
                    .HasColumnType("varchar(5)")
                    .HasColumnName("cap")
                    .HasComment("CAP")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CodiceIstat)
                    .IsRequired()
                    .HasColumnType("varchar(6)")
                    .HasColumnName("codiceIstat")
                    .HasComment("Codice Istat")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CodiceProvincia)
                    .HasColumnType("int(11)")
                    .HasColumnName("codiceProvincia")
                    .HasComment("Provincia");

                entity.Property(e => e.CodiceRegione)
                    .HasColumnType("int(11)")
                    .HasColumnName("codiceRegione")
                    .HasComment("Regione");

                entity.Property(e => e.FlagProvincia)
                    .HasColumnType("int(11)")
                    .HasColumnName("flagProvincia")
                    .HasComment("Flag provincia");

                entity.Property(e => e.FlagRegione)
                    .HasColumnType("int(1)")
                    .HasColumnName("flagRegione");

                entity.Property(e => e.NomeComune)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("nomeComune")
                    .HasComment("Nome comune")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Prefisso)
                    .IsRequired()
                    .HasColumnType("varchar(5)")
                    .HasColumnName("prefisso")
                    .HasComment("Prefisso telefonico")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Comuni)
                    .HasForeignKey(d => d.CodiceProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comuni_ibfk_1");

                entity.HasOne(d => d.Regione)
                    .WithMany(p => p.Comuni)
                    .HasForeignKey(d => d.CodiceRegione)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comuni_ibfk_2");
            });

            modelBuilder.Entity<Azienda>(entity =>
            {
                entity.ToTable("azienda");

                entity.HasComment("Azienda concessionaria");

                entity.HasNoKey();

                entity.Property(e => e.NomeAzienda)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasColumnName("nomeAzienda")
                    .HasComment("Nome azienda")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ToponimoAzienda)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("toponimoAzienda")
                    .HasComment("Toponimo azienda")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IndirizzoAzienda)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("indirizzoAzienda")
                    .HasComment("Indirizzo azienda")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CivicoAzienda)
                    .HasColumnType("int(11)")
                    .HasColumnName("civicoAzienda")
                    .HasComment("Civico Azienda");

                entity.Property(e => e.LetteraAzienda)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("letteraAzienda")
                    .HasComment("Lettera azienda")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LocalitaAzienda)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("localitaAzienda")
                    .HasComment("Località azienda")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CittaAzienda)
                    .HasColumnType("varchar(4)")
                    .HasColumnName("cittaAzienda")
                    .HasComment("Città azienda")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PartitaIvaAzienda)
                    .HasColumnType("varchar(11)")
                    .HasColumnName("partitaIvaAzienda")
                    .HasComment("Partita IVA azienda")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CodiceFiscaleAzienda)
                    .HasColumnType("varchar(11)")
                    .HasColumnName("codiceFiscaleAzienda")
                    .HasComment("Codice fiscale azienda")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.TelefonoAzienda)
                    .HasColumnType("varchar(15)")
                    .HasColumnName("telefonoAzienda")
                    .HasComment("Telefono azienda")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FaxAzienda)
                    .HasColumnType("varchar(15)")
                    .HasColumnName("faxAzienda")
                    .HasComment("Fax azienda")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.EmailAzienda)
                    .HasColumnType("varchar(60)")
                    .HasColumnName("emailAzienda")
                    .HasComment("Email azienda")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PecAzienda)
                    .HasColumnType("varchar(60)")
                    .HasColumnName("pecAzienda")
                    .HasComment("Pec azienda")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ToponimoAgenzia)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("toponimoAgenzia")
                    .HasComment("Toponimo agenzia")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IndirizzoAgenzia)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("indirizzoAgenzia")
                    .HasComment("Indirizzo agenzia")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CivicoAgenzia)
                    .HasColumnType("int(11)")
                    .HasColumnName("civicoAgenzia")
                    .HasComment("Civico Agenzia");

                entity.Property(e => e.LetteraAgenzia)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("letteraAgenzia")
                    .HasComment("Lettera agenzia")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LocalitaAgenzia)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("localitaAgenzia")
                    .HasComment("Località agenzia")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
                
                entity.Property(e => e.CittaAgenzia)
                    .HasColumnType("varchar(4)")
                    .HasColumnName("cittaAgenzia")
                    .HasComment("Città agenzia")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.TelefonoAgenzia)
                    .HasColumnType("varchar(15)")
                    .HasColumnName("telefonoAgenzia")
                    .HasComment("Telefono agenzia")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FaxAgenzia)
                    .HasColumnType("varchar(15)")
                    .HasColumnName("faxAgenzia")
                    .HasComment("Fax agenzia")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.EmailAgenzia)
                    .HasColumnType("varchar(60)")
                    .HasColumnName("emailAgenzia")
                    .HasComment("Email agenzia")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PecAgenzia)
                    .HasColumnType("varchar(60)")
                    .HasColumnName("pecAgenzia")
                    .HasComment("Pec agenzia")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Ente>(entity =>
            {
                entity.HasKey(e => e.CodiceCatastale)
                    .HasName("PRIMARY");

                entity.ToTable("ente");

                entity.HasComment("Dati ente in gestione");

                entity.HasIndex(e => e.CodiceCatastale, "codiceCatastale");

                entity.Property(e => e.CodiceCatastale)
                    .IsRequired()
                    .HasColumnType("varchar(4)")
                    .HasColumnName("codiceCatastale")
                    .HasComment("Codice catastale")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PartitaIva)
                    .HasColumnType("varchar(11)")
                    .HasColumnName("partitaIva")
                    .HasComment("Partita IVA")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CodiceFiscale)
                    .HasColumnType("varchar(11)")
                    .HasColumnName("codiceFiscale")
                    .HasComment("Codice fiscale")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Toponimo)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("toponimo")
                    .HasComment("Toponimo")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Indirizzo)
                    .HasColumnType("varchar(60)")
                    .HasColumnName("indirizzo")
                    .HasComment("CIndirizzo")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Civico)
                    .HasColumnType("int(11)")
                    .HasColumnName("civico")
                    .HasComment("Civico");

                entity.Property(e => e.Lettera)
                    .HasColumnType("varchar(10)")
                    .HasColumnName("lettera")
                    .HasComment("Lettera")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Localita)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("localita")
                    .HasComment("Località")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Telefono)
                    .HasColumnType("varchar(15)")
                    .HasColumnName("telefono")
                    .HasComment("Telefono")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Fax)
                    .HasColumnType("varchar(15)")
                    .HasColumnName("fax")
                    .HasComment("Fax")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(60)")
                    .HasColumnName("email")
                    .HasComment("Email")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Pec)
                    .HasColumnType("varchar(60)")
                    .HasColumnName("pec")
                    .HasComment("Pec")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.TitoloResponsabile)
                    .HasColumnType("varchar(30)")
                    .HasColumnName("titoloResponsabile")
                    .HasComment("Titolo responsabile")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CognomeResponsabile)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("cognomeResponsabile")
                    .HasComment("Cognome responsabile")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NomeResponsabile)
                    .HasColumnType("varchar(40)")
                    .HasColumnName("nomeResponsabile")
                    .HasComment("Nome responsabile")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Comune)
                    .WithOne(p => p.Ente)
                    .HasForeignKey<Ente>(d => d.CodiceCatastale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ente_ibfk_1");
            });

            modelBuilder.Entity<Nazione>(entity =>
            {
                entity.HasKey(e => e.Codice3)
                    .HasName("PRIMARY");

                entity.ToTable("nazioni");

                entity.Property(e => e.Codice3)
                    .HasColumnType("varchar(4)")
                    .HasColumnName("codice3")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Belfiore)
                    .HasColumnType("varchar(4)")
                    .HasColumnName("belfiore")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Codice2)
                    .HasColumnType("varchar(4)")
                    .HasColumnName("codice2")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Codice3Padre)
                    .HasColumnType("varchar(3)")
                    .HasColumnName("codice3Padre")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CodiceArea)
                    .HasColumnType("int(11)")
                    .HasColumnName("codiceArea");

                entity.Property(e => e.CodiceContinente)
                    .HasColumnType("int(11)")
                    .HasColumnName("codiceContinente");

                entity.Property(e => e.DenominazioneEn)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("denominazioneEN")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DenominazioneIt)
                    .HasColumnType("varchar(36)")
                    .HasColumnName("denominazioneIT")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.CodiceProvincia)
                    .HasName("PRIMARY");

                entity.ToTable("province");

                entity.HasIndex(e => e.CodiceCapoluogo, "CodiceCapoluogo")
                    .IsUnique();

                entity.HasIndex(e => e.CodiceRegione, "codiceRegione");

                entity.Property(e => e.CodiceProvincia)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("codiceProvincia");

                entity.Property(e => e.CodiceCapoluogo)
                    .IsRequired()
                    .HasColumnType("varchar(4)")
                    .HasColumnName("codiceCapoluogo")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CodiceRegione)
                    .HasColumnType("int(11)")
                    .HasColumnName("codiceRegione");

                entity.Property(e => e.NomeProvincia)
                    .IsRequired()
                    .HasColumnType("varchar(28)")
                    .HasColumnName("nomeProvincia")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.SiglaProvincia)
                    .IsRequired()
                    .HasColumnType("varchar(2)")
                    .HasColumnName("siglaProvincia")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
/*
                entity.HasOne(d => d.Capoluogo)
                    .WithOne(p => p.Provincia)
                    .HasForeignKey<Provincia>(d => d.CodiceCapoluogo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("province_ibfk_2");
*/
                entity.HasOne(d => d.Regione)
                    .WithMany(p => p.Province)
                    .HasForeignKey(d => d.CodiceRegione)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("province_ibfk_1");
            });

            modelBuilder.Entity<Regione>(entity =>
            {
                entity.HasKey(e => e.CodiceRegione)
                    .HasName("PRIMARY");

                entity.ToTable("regioni");

                entity.HasComment("Elenco delle regioni italiane");

                entity.HasIndex(e => e.CodiceCapoluogo, "codiceCapoluogo");

                entity.Property(e => e.CodiceRegione)
                    .HasColumnType("int(11)")
                    .HasColumnName("codiceRegione")
                    .HasComment("Codice Regione");

                entity.Property(e => e.CodiceCapoluogo)
                    .IsRequired()
                    .HasColumnType("varchar(4)")
                    .HasColumnName("codiceCapoluogo")
                    .HasComment("Codice capoluogo di regione")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NomeRegione)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasColumnName("nomeRegione")
                    .HasComment("Nome Regione")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.RipartizioneGeografica)
                    .HasColumnType("int(11)")
                    .HasColumnName("ripartizioneGeografica")
                    .HasComment("Ripartizione geografica");
                /*
                entity.HasOne(d => d.Capoluogo)
                    .WithMany(p => p.Regioni)
                    .HasForeignKey(d => d.CodiceCapoluogo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("regioni_ibfk_1");
                */
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
