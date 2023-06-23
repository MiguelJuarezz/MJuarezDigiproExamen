using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class MjuarezDigiproExamenContext : DbContext
{
    public MjuarezDigiproExamenContext()
    {
    }

    public MjuarezDigiproExamenContext(DbContextOptions<MjuarezDigiproExamenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<AlumnoMaterium> AlumnoMateria { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= MJuarezDigiproExamen; Trusted_Connection=True; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno).HasName("PK__Alumno__460B47402326A4D9");

            entity.ToTable("Alumno");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AlumnoMaterium>(entity =>
        {
            entity.HasKey(e => e.IdAlumnoMateria).HasName("PK__AlumnoMa__E13EDA37FA1566E3");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.AlumnoMateria)
                .HasForeignKey(d => d.IdAlumno)
                .HasConstraintName("FK__AlumnoMat__IdAlu__276EDEB3");

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.AlumnoMateria)
                .HasForeignKey(d => d.IdMateria)
                .HasConstraintName("FK__AlumnoMat__IdMat__286302EC");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.IdMateria).HasName("PK__Materia__EC174670C91021B8");

            entity.Property(e => e.Costo).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Usuario");

            entity.Property(e => e.IdUsuario).ValueGeneratedOnAdd();
            entity.Property(e => e.Password)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
