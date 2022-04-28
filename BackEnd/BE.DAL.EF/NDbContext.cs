using System;
using System.Collections.Generic;
using System.Text;
using BE.DAL.DO.Objetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BE.DAL.EF
{
    public partial class NDbContext: DbContext
    {
        public NDbContext()
        {
        }
        public NDbContext(DbContextOptions<NDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Categoria> Categoria { get; set; }

        public virtual DbSet<Marca> Marca { get; set; }

        public virtual DbSet<Producto> Producto { get; set; }

        public virtual DbSet<Provincia> Provincia { get; set; }

        public virtual DbSet<Instalador> Instalador { get; set; }

        public virtual DbSet<Contacto> Contacto { get; set; }

        public virtual DbSet<Venta> Venta { get; set; }

        public virtual DbSet<Detalleventa> Detalleventa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Idcategoria)
                    .HasName("PK__CATEGORI__ADC0E71986A03ED0");

                entity.ToTable("CATEGORIA");

                entity.Property(e => e.Idcategoria).HasColumnName("IDCATEGORIA");

                entity.Property(e => e.Activo)
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => e.Idcontacto)
                    .HasName("PK__CONTACTO__4F3DCD412990844C");

                entity.ToTable("CONTACTO");

                entity.Property(e => e.Idcontacto).HasColumnName("IDCONTACTO");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("CORREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasColumnName("MENSAJE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Instalador>(entity =>
            {
                entity.HasKey(e => e.IdInstalador)
                    .HasName("PK__INSTALAD__F033D4040276726B");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Instalador)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK__INSTALADO__IdPro__5812160E");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__MARCA__4076A887E6695525");

                entity.ToTable("MARCA");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("PK__PRODUCTO__7D8DC0F14C1EBEC2");

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Idproducto).HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Activo)
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Codigo)
                    .HasColumnName("CODIGO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Idcategoria).HasColumnName("IDCATEGORIA");

                entity.Property(e => e.Idmarca).HasColumnName("IDMARCA");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Valorcodigo).HasColumnName("VALORCODIGO");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK__PRODUCTO__IDCATE__3A81B327");

                entity.HasOne(d => d.IdmarcaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.Idmarca)
                    .HasConstraintName("FK__PRODUCTO__IDMARC__7F2BE32F");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("PK__PROVINCI__EED7445506097544");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.Idventa)
                    .HasName("PK__VENTA__2849CB579CB150EC");

                entity.Property(e => e.Iva)
                    .IsRequired();

                entity.Property(e => e.Total)
                    .IsRequired();

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Detalleventa>(entity =>
            {
                entity.HasKey(e => e.Iddetalleventa)
                    .HasName("PK__VENTA__2849CB579CB150EC");

                entity.Property(e => e.Idventa).HasColumnName("IDVENTA");

                entity.Property(e => e.Idproducto).HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Cantidad)
                    .IsRequired();

                entity.Property(e => e.Importetotal)
                    .IsRequired();

                entity.Property(e => e.Descuento)
                    .IsRequired();

                entity.Property(e => e.Activo);

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Detalleventa)
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("FK__DETALLEVE__IDPRO__5441852A");

                entity.HasOne(d => d.IdventaNavigation)
                    .WithMany(v => v.Detalleventa)
                    .HasForeignKey(d => d.Idventa)
                    .HasConstraintName("FK__DETALLEVE__IDVEN__5535A963");
            });



            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
