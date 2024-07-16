using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppWebBlazor.Server.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Detalleventa> Detalleventa { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Detalleventa>(entity =>
        {
            entity.HasKey(e => e.Iddetalleventa).HasName("PK__detallev__4EA18098A4536305");

            entity.ToTable("detalleventa");

            entity.Property(e => e.Iddetalleventa).HasColumnName("iddetalleventa");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Idventa).HasColumnName("idventa");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.Idproducto)
                .HasConstraintName("FK__detalleve__idpro__29572725");

            entity.HasOne(d => d.IdventaNavigation).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.Idventa)
                .HasConstraintName("FK__detalleve__idven__286302EC");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__producto__DC53BE3C65B9DF8B");

            entity.ToTable("producto");

            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Idventa).HasName("PK__venta__F82D1AFBCAD7A164");

            entity.ToTable("venta");

            entity.Property(e => e.Idventa).HasColumnName("idventa");
            entity.Property(e => e.Cliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliente");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
