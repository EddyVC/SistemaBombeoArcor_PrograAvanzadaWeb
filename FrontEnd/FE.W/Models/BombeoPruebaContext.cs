using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class BombeoPruebaContext : DbContext
    {
        public BombeoPruebaContext()
        {
        }

        public BombeoPruebaContext(DbContextOptions<BombeoPruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Carrito> Carrito { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Detalleventa> Detalleventa { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Instalador> Instalador { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-18BMGEL\\SQLEXPRESS;Database=BombeoPrueba;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => e.Idcarrito)
                    .HasName("PK__CARRITO__BDDE160ECCC7DEF5");

                entity.ToTable("CARRITO");

                entity.Property(e => e.Idcarrito).HasColumnName("IDCARRITO");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Idproducto).HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Idusuario)
                    .IsRequired()
                    .HasColumnName("IDUSUARIO")
                    .HasMaxLength(128);

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Carrito)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CARRITO__IDPRODU__46E78A0C");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Carrito)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CARRITO__IDUSUAR__47DBAE45");
            });

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

            modelBuilder.Entity<Detalleventa>(entity =>
            {
                entity.HasKey(e => e.Iddetalleventa)
                    .HasName("PK__DETALLEV__BB16C8540C19E6A2");

                entity.ToTable("DETALLEVENTA");

                entity.Property(e => e.Iddetalleventa).HasColumnName("IDDETALLEVENTA");

                entity.Property(e => e.Activo)
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Descuento)
                    .HasColumnName("DESCUENTO")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Idproducto).HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Idventa).HasColumnName("IDVENTA");

                entity.Property(e => e.Importetotal)
                    .HasColumnName("IMPORTETOTAL")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Preciounidad)
                    .HasColumnName("PRECIOUNIDAD")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Detalleventa)
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("FK__DETALLEVE__IDPRO__6C190EBB");

                entity.HasOne(d => d.IdventaNavigation)
                    .WithMany(p => p.Detalleventa)
                    .HasForeignKey(d => d.Idventa)
                    .HasConstraintName("FK__DETALLEVE__IDVEN__6D0D32F4");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.Idfactura)
                    .HasName("PK__FACTURA__F7D4C9C779E154CB");

                entity.ToTable("FACTURA");

                entity.Property(e => e.Idfactura)
                    .HasColumnName("IDFACTURA")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descuento)
                    .HasColumnName("DESCUENTO")
                    .HasColumnType("money");

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasColumnType("date");

                entity.Property(e => e.Iva).HasColumnName("IVA");

                entity.Property(e => e.Numpago).HasColumnName("NUMPAGO");

                entity.Property(e => e.Total).HasColumnName("TOTAL");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasKey(e => e.Idhistory)
                    .HasName("PK__HISTORY__5D44165CDC2B9884");

                entity.ToTable("HISTORY");

                entity.Property(e => e.Idhistory).HasColumnName("IDHISTORY");

                entity.Property(e => e.Fechahistory)
                    .HasColumnName("FECHAHISTORY")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Idproducto).HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Iduser)
                    .HasColumnName("IDUSER")
                    .HasMaxLength(128);

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("FK_HISTORY_PRODUCTS");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("FK_HISTORY_USER");
            });

            modelBuilder.Entity<Instalador>(entity =>
            {
                entity.HasKey(e => e.IdInstalador)
                    .HasName("PK__INSTALAD__F033D4040276726B");

                entity.ToTable("INSTALADOR");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Instalador)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK__INSTALADO__IdPro__6754599E");
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

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
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

                entity.ToTable("PROVINCIA");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.Idventa)
                    .HasName("PK__VENTA__2849CB5775AC91A2");

                entity.ToTable("VENTA");

                entity.Property(e => e.Idventa).HasColumnName("IDVENTA");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Idusuario)
                    .HasColumnName("IDUSUARIO")
                    .HasMaxLength(128);

                entity.Property(e => e.Iva).HasColumnName("IVA");

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK__VENTA__IDUSUARIO__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
