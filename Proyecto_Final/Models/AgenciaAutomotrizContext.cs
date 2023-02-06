using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Final.Models;

public partial class AgenciaAutomotrizContext : DbContext
{
    public AgenciaAutomotrizContext()
    {
    }

    public AgenciaAutomotrizContext(DbContextOptions<AgenciaAutomotrizContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auto> Autos { get; set; }

    public virtual DbSet<Moto> Motos { get; set; }

    public virtual DbSet<Refaccione> Refacciones { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=LAPTOP-IQTO5P3K\\SQLEXPRESS; database=Agencia_automotriz; Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auto>(entity =>
        {
            entity.HasKey(e => e.IdAuto).HasName("PK__Autos__2C8AA82C58C312E9");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Color)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Moto>(entity =>
        {
            entity.HasKey(e => e.IdMoto).HasName("PK__Motos__33CED5FBEB5EDB11");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Color)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Refaccione>(entity =>
        {
            entity.HasKey(e => e.IdRefaccion).HasName("PK__Refaccio__1049334BCAB97E5B");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
