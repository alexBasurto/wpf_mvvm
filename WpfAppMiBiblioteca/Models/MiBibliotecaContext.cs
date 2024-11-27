using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfAppMiBiblioteca.Models;

public partial class MiBibliotecaContext : DbContext
{
    public MiBibliotecaContext()
    {
    }

    public MiBibliotecaContext(DbContextOptions<MiBibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autores> Autores { get; set; }

    public virtual DbSet<Editoriales> Editoriales { get; set; }

    public virtual DbSet<Libros> Libros { get; set; }

    public virtual DbSet<Operaciones> Operaciones { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=THINKPAD;Initial Catalog=MiBiblioteca;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Autores__3214EC0775D1A91D");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Editoriales>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Editoria__3214EC07EC96AA7F");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Libros>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PK__Libros__447D36EBAD7E3A7A");

            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .HasColumnName("ISBN");
            entity.Property(e => e.Precio).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.Titulo).HasMaxLength(150);

            entity.HasOne(d => d.Autor).WithMany(p => p.Libros)
                .HasForeignKey(d => d.AutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Autores_Libros");

            entity.HasOne(d => d.Editorial).WithMany(p => p.Libros)
                .HasForeignKey(d => d.EditorialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Editoriales_Libros");
        });

        modelBuilder.Entity<Operaciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Operacio__3214EC07D84EC6A9");

            entity.Property(e => e.Controller).HasMaxLength(50);
            entity.Property(e => e.FechaAccion).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(50);
            entity.Property(e => e.Operacion).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC0781B30C00");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EnlaceCambioPass).HasMaxLength(500);
            entity.Property(e => e.FechaEnvioEnlace).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
