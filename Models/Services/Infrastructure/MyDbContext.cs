using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using KampusStudioProto.Models.Entities;

#nullable disable

namespace KampusStudioProto.Models.Services.Infrastructure
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comune> Comuni { get; set; }
        public virtual DbSet<Nazione> Nazioni { get; set; }
        public virtual DbSet<Provincia> Province { get; set; }
        public virtual DbSet<Regione> Regioni { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

                entity.HasIndex(e => e.CodiceRegione, "codiceRegione");

                entity.Property(e => e.CodiceProvincia)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("codiceProvincia");

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
                entity.HasOne(d => d.CodiceCapoluogoNavigation)
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
