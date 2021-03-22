using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Common.Models
{
    public partial class BDEscuelaContext : DbContext
    {
        public BDEscuelaContext()
        {
        }

        public BDEscuelaContext(DbContextOptions<BDEscuelaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Direccion> Direcciones { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<EstudianteCurso> EstudianteCursos { get; set; }
        public virtual DbSet<EstudianteDireccion> EstudianteDirecciones { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=localhost;Database=BDEscuela;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.ToTable("Curso");

                entity.Property(e => e.FechaFin).HasMaxLength(10);

                entity.Property(e => e.FechaInicio).HasMaxLength(10);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Tiempo).HasMaxLength(10);
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.ToTable("Direccion");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("Estudiante");

                entity.Property(e => e.Edad).HasMaxLength(10);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<EstudianteCurso>(entity =>
            {
                entity.HasKey(e => e.IdEstudianteCurso)
                    .HasName("PK__Estudian__D4C2F4F992D96477");

                entity.ToTable("EstudianteCurso");

                entity.HasOne(d => d.CursoNavigation)
                    .WithMany(p => p.EstudianteCursos)
                    .HasForeignKey(d => d.Curso)
                    .HasConstraintName("FK__Estudiante__Curso");

                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.EstudianteCursos)
                    .HasForeignKey(d => d.Estudiante)
                    .HasConstraintName("FK__Estudiante__EstudianteCurso");
            });

            modelBuilder.Entity<EstudianteDireccion>(entity =>
            {
                entity.HasKey(e => e.IdEstudianteDireccion)
                    .HasName("PK__Estudian__B6DAA0B940EB0309");

                entity.ToTable("EstudianteDireccion");

                entity.HasOne(d => d.DireccionNavigation)
                    .WithMany(p => p.EstudianteDireccions)
                    .HasForeignKey(d => d.Direccion)
                    .HasConstraintName("FK__Estudiante__Direccion");

                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.EstudianteDireccions)
                    .HasForeignKey(d => d.Estudiante)
                    .HasConstraintName("FK__Estudiante__EstudianteD");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
