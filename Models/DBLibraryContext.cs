using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LibraryApplication.ViewModel;

#nullable disable

namespace LibraryApplication
{
    public partial class DBLibraryContext : DbContext
    {
        public DBLibraryContext()
        {
        }

        public DBLibraryContext(DbContextOptions<DBLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorsBook> AuthorsBooks { get; set; }
        public virtual DbSet<AuthorsCountry> AuthorsCountries { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<GenresBook> GenresBooks { get; set; }

        public virtual DbSet<FirstRequest> FirstRequests { get; set; }

        public virtual DbSet<SecondRequest> SecondRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-5R9TST7; Database=DBLibrary; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<AuthorsBook>(entity =>
            {
                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorsBooks)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Authors_AuthorsBooks");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.AuthorsBooks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_AuthorsBooks");
            });

            modelBuilder.Entity<AuthorsCountry>(entity =>
            {
                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorsCountries)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Authors_AuthorsCountries");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.AuthorsCountries)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Countries_AuthorsCountries");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Fb2)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pdf)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("PDF");

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Comments");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<GenresBook>(entity =>
            {
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.GenresBooks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_GenresBooks");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.GenresBooks)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Genres_GenresBooks");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
