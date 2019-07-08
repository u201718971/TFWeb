using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Models
{
    public partial class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext()
        {
        }

        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Deporte> Deporte { get; set; }
        public virtual DbSet<GeneroProducto> GeneroProducto { get; set; }
        public virtual DbSet<ListaVenta> ListaVenta { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<TipoDePrueba> TipoDePrueba { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=JVA005;Initial Catalog=BD_TrabajoWeb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Deporte>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneroProducto>(entity =>
            {
                entity.ToTable("Genero_Producto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ListaVenta>(entity =>
            {
                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.ListaVenta)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__ListaVent__Produ__1DE57479");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.ListaVenta)
                    .HasForeignKey(d => d.VentaId)
                    .HasConstraintName("FK__ListaVent__Venta__1CF15040");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Foto)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Genero)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.GeneroId)
                    .HasConstraintName("FK_Producto_Genero_Producto");

                entity.HasOne(d => d.TipoProducto)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.TipoProductoId)
                    .HasConstraintName("FK__Producto__TipoPr__182C9B23");
            });

            modelBuilder.Entity<TipoDePrueba>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Deporte)
                    .WithMany(p => p.TipoDePrueba)
                    .HasForeignKey(d => d.DeporteId)
                    .HasConstraintName("FK__TipoDePru__Depor__1273C1CD");
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoDePrueba)
                    .WithMany(p => p.TipoProducto)
                    .HasForeignKey(d => d.TipoDePruebaId)
                    .HasConstraintName("FK__TipoProdu__TipoD__15502E78");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.Property(e => e.DiaVenta).HasColumnType("datetime");
            });
        }
    }
}
