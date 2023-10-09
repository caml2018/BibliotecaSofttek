using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Softtek.Biblioteca.Domain.Entities.Models;

#nullable disable

namespace Softtek.Biblioteca.Infrastructure.EFDataAccess
{
    public partial class DbTestBibliotecaSofttekContext : DbContext
    {
        public DbTestBibliotecaSofttekContext()
        {
        }

        public DbTestBibliotecaSofttekContext(DbContextOptions<DbTestBibliotecaSofttekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-TN31B2J;Database=DbTestBibliotecaSofttek; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("autor", "biblioteca");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CiudadProcedencia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ciudadProcedencia");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("correoElectronico");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("nombreCompleto");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("libro", "biblioteca");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AutorId).HasColumnName("autorId");

                entity.Property(e => e.Año)
                    .HasColumnName("año");

                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("genero");

                entity.Property(e => e.NumeroPaginas).HasColumnName("numeroPaginas");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.AutorId)
                    .HasConstraintName("FK_libro_autor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
