using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace biblioteka___nowy_projekt.Models
{
    public partial class dbbibliotekaContext : DbContext
    {
        public dbbibliotekaContext()
        {
        }

        public dbbibliotekaContext(DbContextOptions<dbbibliotekaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Czytelnik> Czytelnik { get; set; }
        public virtual DbSet<Kategoria> Kategoria { get; set; }
        public virtual DbSet<Ksiazka> Ksiazka { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db-biblioteka;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Czytelnik>(entity =>
            {
                entity.HasKey(e => e.IdCzytelnik)
                    .HasName("PK__Czytelni__930228A0C16893BC");

                entity.Property(e => e.IdCzytelnik).HasColumnName("Id_czytelnik");

                entity.Property(e => e.Imie)
                    .HasColumnName("imie")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Miasto)
                    .HasColumnName("miasto")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .HasColumnName("nazwisko")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasColumnName("telefon")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kategoria>(entity =>
            {
                entity.HasKey(e => e.IdKategoria)
                    .HasName("PK__Kategori__AEFCAE468F7BD47F");

                entity.Property(e => e.IdKategoria).HasColumnName("Id_kategoria");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ksiazka>(entity =>
            {
                entity.HasKey(e => e.IdKsiazka)
                    .HasName("PK__Ksiazka__11D1C823156DC51E");

                entity.Property(e => e.IdKsiazka).HasColumnName("Id_Ksiazka");

                entity.Property(e => e.Autor)
                    .HasColumnName("autor")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KategorieId).HasColumnName("kategorie_id");

                entity.Property(e => e.RokWydania)
                    .HasColumnName("rok_wydania")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tytul)
                    .HasColumnName("tytul")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Wydawnictwo)
                    .HasColumnName("wydawnictwo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Kategorie)
                    .WithMany(p => p.Ksiazka)
                    .HasForeignKey(d => d.KategorieId)
                    .HasConstraintName("FK_Ksiazka_ToKategorie");
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("PK__Zamowien__2E82864096D7305F");

                entity.Property(e => e.IdZamowienie).HasColumnName("Id_zamowienie");

                entity.Property(e => e.CzytelnikId).HasColumnName("czytelnik_id");

                entity.Property(e => e.DataZamowienia)
                    .HasColumnName("data_zamowienia")
                    .HasColumnType("datetime");

                entity.Property(e => e.KsiazkaId).HasColumnName("ksiazka_id");

                entity.HasOne(d => d.Czytelnik)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.CzytelnikId)
                    .HasConstraintName("FK_Zamowienie_ToCzytelnik");

                entity.HasOne(d => d.Ksiazka)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.KsiazkaId)
                    .HasConstraintName("FK_Zamowienie_ToKsiazka");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
