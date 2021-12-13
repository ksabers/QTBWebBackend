using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QTBWebBackend.Models
{
    public partial class QTBWebDBContext : DbContext
    {
        public QTBWebDBContext()
        {
        }

        public QTBWebDBContext(DbContextOptions<QTBWebDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aerei> Aereis { get; set; }
        public virtual DbSet<AereiPosseduti> AereiPossedutis { get; set; }
        public virtual DbSet<Aeroporti> Aeroportis { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Manutenzioni> Manutenzionis { get; set; }
        public virtual DbSet<Persone> Persones { get; set; }
        public virtual DbSet<Ruoli> Ruolis { get; set; }
        public virtual DbSet<ScadenzeAerei> ScadenzeAereis { get; set; }
        public virtual DbSet<ScadenzePersone> ScadenzePersones { get; set; }
        public virtual DbSet<TipiAeroporti> TipiAeroportis { get; set; }
        public virtual DbSet<TipiScadenzeAerei> TipiScadenzeAereis { get; set; }
        public virtual DbSet<TipiScadenzePersone> TipiScadenzePersones { get; set; }
        public virtual DbSet<Voli> Volis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Aerei>(entity =>
            {
                entity.ToTable("Aerei");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Costruttore)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("costruttore");

                entity.Property(e => e.Marche)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("marche");

                entity.Property(e => e.MinutiPregressi).HasColumnName("minuti_pregressi");

                entity.Property(e => e.Modello)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("modello");

                entity.Property(e => e.PesoVuoto).HasColumnName("peso_vuoto");
            });

            modelBuilder.Entity<AereiPosseduti>(entity =>
            {
                entity.ToTable("AereiPosseduti");

                entity.HasIndex(e => new { e.Persona, e.Aereo }, "IX_AereiPosseduti")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aereo).HasColumnName("aereo");

                entity.Property(e => e.Persona).HasColumnName("persona");

                entity.Property(e => e.Quota).HasColumnName("quota");

                entity.HasOne(d => d.AereoNavigation)
                    .WithMany(p => p.AereiPossedutis)
                    .HasForeignKey(d => d.Aereo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AereiPosseduti_Aerei");

                entity.HasOne(d => d.PersonaNavigation)
                    .WithMany(p => p.AereiPossedutis)
                    .HasForeignKey(d => d.Persona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AereiPosseduti_Persone");
            });

            modelBuilder.Entity<Aeroporti>(entity =>
            {
                entity.ToTable("Aeroporti");

                entity.HasIndex(e => e.Identificativo, "IX_Aeroporti")
                    .IsUnique();

                entity.HasIndex(e => e.Nome, "IX_Aeroporti_1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Asfalto).HasColumnName("asfalto");

                entity.Property(e => e.Coordinate)
                    .HasMaxLength(50)
                    .HasColumnName("coordinate");

                entity.Property(e => e.Denominazione).HasColumnName("denominazione");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Iata)
                    .HasMaxLength(3)
                    .HasColumnName("IATA");

                entity.Property(e => e.Icao)
                    .HasMaxLength(4)
                    .HasColumnName("ICAO");

                entity.Property(e => e.Identificativo)
                    .HasMaxLength(4)
                    .HasColumnName("identificativo");

                entity.Property(e => e.Indirizzo)
                    .HasMaxLength(100)
                    .HasColumnName("indirizzo");

                entity.Property(e => e.Lunghezza).HasColumnName("lunghezza");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Qfu)
                    .HasMaxLength(10)
                    .HasColumnName("QFU");

                entity.Property(e => e.Qnh).HasColumnName("QNH");

                entity.Property(e => e.Radio)
                    .HasMaxLength(50)
                    .HasColumnName("radio");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .HasColumnName("telefono");

                entity.Property(e => e.TipoAeroporto).HasColumnName("tipo_aeroporto");

                entity.Property(e => e.Web)
                    .HasMaxLength(50)
                    .HasColumnName("web");

                entity.HasOne(d => d.TipoAeroportoNavigation)
                    .WithMany(p => p.Aeroportis)
                    .HasForeignKey(d => d.TipoAeroporto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Aeroporti_TipiAeroporti");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Persona).HasColumnName("persona");

                entity.Property(e => e.Ruolo).HasColumnName("ruolo");

                entity.HasOne(d => d.PersonaNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Persona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Login_Persone");

                entity.HasOne(d => d.RuoloNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Ruolo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Login_Ruoli");
            });

            modelBuilder.Entity<Manutenzioni>(entity =>
            {
                entity.ToTable("Manutenzioni");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aereo).HasColumnName("aereo");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasColumnName("descrizione");

                entity.Property(e => e.Persona).HasColumnName("persona");

                entity.Property(e => e.Volo).HasColumnName("volo");

                entity.HasOne(d => d.AereoNavigation)
                    .WithMany(p => p.Manutenzionis)
                    .HasForeignKey(d => d.Aereo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manutenzioni_Aerei");

                entity.HasOne(d => d.PersonaNavigation)
                    .WithMany(p => p.Manutenzionis)
                    .HasForeignKey(d => d.Persona)
                    .HasConstraintName("FK_Manutenzioni_Persone");

                entity.HasOne(d => d.VoloNavigation)
                    .WithMany(p => p.Manutenzionis)
                    .HasForeignKey(d => d.Volo)
                    .HasConstraintName("FK_Manutenzioni_Voli");
            });

            modelBuilder.Entity<Persone>(entity =>
            {
                entity.ToTable("Persone");

                entity.HasIndex(e => e.Cognome, "IX_Persone");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AeroportoBase).HasColumnName("aeroporto_base");

                entity.Property(e => e.Cap)
                    .HasMaxLength(50)
                    .HasColumnName("cap");

                entity.Property(e => e.Citta)
                    .HasMaxLength(50)
                    .HasColumnName("citta");

                entity.Property(e => e.Cognome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cognome");

                entity.Property(e => e.Indirizzo)
                    .HasMaxLength(50)
                    .HasColumnName("indirizzo");

                entity.Property(e => e.MinutiPregressi).HasColumnName("minuti_pregressi");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.Pilota).HasColumnName("pilota");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .HasColumnName("telefono");

                entity.Property(e => e.Tessera)
                    .HasMaxLength(50)
                    .HasColumnName("tessera");

                entity.HasOne(d => d.AeroportoBaseNavigation)
                    .WithMany(p => p.Persones)
                    .HasForeignKey(d => d.AeroportoBase)
                    .HasConstraintName("FK_Persone_Aeroporti");
            });

            modelBuilder.Entity<Ruoli>(entity =>
            {
                entity.ToTable("Ruoli");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descrizione");
            });

            modelBuilder.Entity<ScadenzeAerei>(entity =>
            {
                entity.ToTable("ScadenzeAerei");

                entity.HasIndex(e => e.Data, "IX_ScadenzeAerei");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aereo).HasColumnName("aereo");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Risolta).HasColumnName("risolta");

                entity.Property(e => e.TipoScadenza).HasColumnName("tipo_scadenza");

                entity.HasOne(d => d.AereoNavigation)
                    .WithMany(p => p.ScadenzeAereis)
                    .HasForeignKey(d => d.Aereo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScadenzeAerei_Aerei");

                entity.HasOne(d => d.TipoScadenzaNavigation)
                    .WithMany(p => p.ScadenzeAereis)
                    .HasForeignKey(d => d.TipoScadenza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScadenzeAerei_TipiScadenzeAerei");
            });

            modelBuilder.Entity<ScadenzePersone>(entity =>
            {
                entity.ToTable("ScadenzePersone");

                entity.HasIndex(e => e.Data, "IX_ScadenzePersone");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Persona).HasColumnName("persona");

                entity.Property(e => e.Risolta).HasColumnName("risolta");

                entity.Property(e => e.TipoScadenza).HasColumnName("tipo_scadenza");

                entity.HasOne(d => d.PersonaNavigation)
                    .WithMany(p => p.ScadenzePersones)
                    .HasForeignKey(d => d.Persona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScadenzePersone_Persone");

                entity.HasOne(d => d.TipoScadenzaNavigation)
                    .WithMany(p => p.ScadenzePersones)
                    .HasForeignKey(d => d.TipoScadenza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScadenzePersone_TipiScadenzePersone");
            });

            modelBuilder.Entity<TipiAeroporti>(entity =>
            {
                entity.ToTable("TipiAeroporti");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descrizione");
            });

            modelBuilder.Entity<TipiScadenzeAerei>(entity =>
            {
                entity.ToTable("TipiScadenzeAerei");

                entity.HasIndex(e => e.Descrizione, "IX_TipiScadenzeAerei")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TipiScadenzePersone>(entity =>
            {
                entity.ToTable("TipiScadenzePersone");

                entity.HasIndex(e => e.Descrizione, "IX_TipiScadenzePersone")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descrizione");
            });

            modelBuilder.Entity<Voli>(entity =>
            {
                entity.ToTable("Voli");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aereo).HasColumnName("aereo");

                entity.Property(e => e.AeroportoFine).HasColumnName("aeroporto_fine");

                entity.Property(e => e.AeroportoInizio).HasColumnName("aeroporto_inizio");

                entity.Property(e => e.Bagaglio).HasColumnName("bagaglio");

                entity.Property(e => e.CarburanteAggiuntoDx).HasColumnName("carburante_aggiunto_dx");

                entity.Property(e => e.CarburanteAggiuntoSx).HasColumnName("carburante_aggiunto_sx");

                entity.Property(e => e.CarburanteInizialeDx).HasColumnName("carburante_iniziale_dx");

                entity.Property(e => e.CarburanteInizialeSx).HasColumnName("carburante_iniziale_sx");

                entity.Property(e => e.Descrizione).HasColumnName("descrizione");

                entity.Property(e => e.Durata)
                    .HasColumnName("durata")
                    .HasComputedColumnSql("(([orametro_ore_fine]*(60)+[orametro_minuti_fine])-([orametro_ore_inizio]*(60)+[orametro_minuti_inizio]))", true);

                entity.Property(e => e.Olio).HasColumnName("olio");

                entity.Property(e => e.OraFine)
                    .HasColumnType("datetime")
                    .HasColumnName("ora_fine");

                entity.Property(e => e.OraInizio)
                    .HasColumnType("datetime")
                    .HasColumnName("ora_inizio")
                    .HasComputedColumnSql("(dateadd(minute, -(([orametro_ore_fine]*(60)+[orametro_minuti_fine])-([orametro_ore_inizio]*(60)+[orametro_minuti_inizio])),[ora_fine]))", true);

                entity.Property(e => e.OraLocaleAtterraggio)
                    .HasMaxLength(5)
                    .HasColumnName("ora_locale_atterraggio");

                entity.Property(e => e.OraLocaleDecollo)
                    .HasMaxLength(5)
                    .HasColumnName("ora_locale_decollo");

                entity.Property(e => e.OrametroMinutiFine).HasColumnName("orametro_minuti_fine");

                entity.Property(e => e.OrametroMinutiInizio).HasColumnName("orametro_minuti_inizio");

                entity.Property(e => e.OrametroOreFine).HasColumnName("orametro_ore_fine");

                entity.Property(e => e.OrametroOreInizio).HasColumnName("orametro_ore_inizio");

                entity.Property(e => e.Passeggero).HasColumnName("passeggero");

                entity.Property(e => e.PesoOccupanti).HasColumnName("peso_occupanti");

                entity.Property(e => e.Pilota).HasColumnName("pilota");

                entity.HasOne(d => d.AereoNavigation)
                    .WithMany(p => p.Volis)
                    .HasForeignKey(d => d.Aereo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Voli_Aerei");

                entity.HasOne(d => d.AeroportoFineNavigation)
                    .WithMany(p => p.VoliAeroportoFineNavigations)
                    .HasForeignKey(d => d.AeroportoFine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Voli_Aeroporti1");

                entity.HasOne(d => d.AeroportoInizioNavigation)
                    .WithMany(p => p.VoliAeroportoInizioNavigations)
                    .HasForeignKey(d => d.AeroportoInizio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Voli_Aeroporti");

                entity.HasOne(d => d.PasseggeroNavigation)
                    .WithMany(p => p.VoliPasseggeroNavigations)
                    .HasForeignKey(d => d.Passeggero)
                    .HasConstraintName("FK_Voli_Persone1");

                entity.HasOne(d => d.PilotaNavigation)
                    .WithMany(p => p.VoliPilotaNavigations)
                    .HasForeignKey(d => d.Pilota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Voli_Persone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
