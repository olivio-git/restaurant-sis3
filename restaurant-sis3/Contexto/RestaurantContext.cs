using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using restaurant_sis3.Modelos;

namespace restaurant_sis3.Contexto;

public partial class RestaurantContext : DbContext
{
    public RestaurantContext()
    {
    }

    public RestaurantContext(DbContextOptions<RestaurantContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; } //mostajo

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Descuento> Descuentos { get; set; }

    public virtual DbSet<DetallesPedido> DetallesPedidos { get; set; }//qui

    public virtual DbSet<Empleado> Empleados { get; set; } //olivio

    public virtual DbSet<Ingrediente> Ingredientes { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; } 

    public virtual DbSet<Producto> Productos { get; set; }//aqui

    public virtual DbSet<Promociones> Promociones { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-E9LI1EM; Initial Catalog=Restaurant; Integrated Security=True; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C533842783");

            entity.Property(e => e.CategoriaId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A78D63E778");

            entity.Property(e => e.ClienteId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.ComentarioId).HasName("PK__Comentar__F1844958C00BB533");

            entity.Property(e => e.ComentarioId).ValueGeneratedNever();

            entity.HasOne(d => d.Cliente).WithMany(p => p.Comentarios).HasConstraintName("FK__Comentari__Clien__6D0D32F4");
        });

        modelBuilder.Entity<Descuento>(entity =>
        {
            entity.HasKey(e => e.DescuentoId).HasName("PK__Descuent__0C2C1138A4E100B0");

            entity.Property(e => e.DescuentoId).ValueGeneratedNever();
        });

        modelBuilder.Entity<DetallesPedido>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__Detalles__6E19D6FADC6BCCDF");

            entity.Property(e => e.DetalleId).ValueGeneratedNever();

            entity.HasOne(d => d.Pedido).WithMany(p => p.DetallesPedidos).HasConstraintName("FK__DetallesP__Pedid__7D439ABD");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallesPedidos).HasConstraintName("FK__DetallesP__Produ__7E37BEF6");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE6F0775BCD28");

            entity.Property(e => e.EmpleadoId).ValueGeneratedNever();

            entity.HasOne(d => d.Rol).WithMany(p => p.Empleados).HasConstraintName("FK__Empleados__RolID__5AEE82B9");
        });

        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.HasKey(e => e.IngredienteId).HasName("PK__Ingredie__CCB95EC8D4043641");

            entity.Property(e => e.IngredienteId).ValueGeneratedNever();

            entity.HasOne(d => d.Producto).WithMany(p => p.Ingredientes).HasConstraintName("FK__Ingredien__Produ__0C85DE4D");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.InventarioId).HasName("PK__Inventar__FB8A24B7F057BC83");

            entity.Property(e => e.InventarioId).ValueGeneratedNever();

            entity.HasOne(d => d.Ingrediente).WithMany(p => p.Inventarios).HasConstraintName("FK__Inventari__Ingre__76969D2E");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.MesaId).HasName("PK__Mesas__6A4196C85BC5E64B");

            entity.Property(e => e.MesaId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("PK__Pedidos__09BA1410F7D1875A");

            entity.Property(e => e.PedidoId).ValueGeneratedNever();

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos).HasConstraintName("FK__Pedidos__Cliente__6477ECF3");

            entity.HasOne(d => d.Descuento).WithMany(p => p.Pedidos).HasConstraintName("FK__Pedidos__Descuen__0A9D95DB");

            entity.HasOne(d => d.Promocion).WithMany(p => p.Pedidos).HasConstraintName("FK__Pedidos__Promoci__09A971A2");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Pedidos).HasConstraintName("FK__Pedidos__Usuario__0D7A0286");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE83DFB98406");

            entity.Property(e => e.ProductoId).ValueGeneratedNever();

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos).HasConstraintName("FK__Productos__Categ__797309D9");

            entity.HasOne(d => d.Inventario).WithMany(p => p.Productos).HasConstraintName("FK__Productos__Inven__0B91BA14");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Productos).HasConstraintName("FK__Productos__Prove__7A672E12");
        });

        modelBuilder.Entity<Promociones>(entity =>
        {
            entity.HasKey(e => e.PromocionId).HasName("PK__Promocio__2DA61DBDCF2D8ABE");

            entity.Property(e => e.PromocionId).ValueGeneratedNever();

            entity.HasOne(d => d.Descuento).WithMany(p => p.Promociones).HasConstraintName("FK__Promocion__Descu__71D1E811");
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PK__Proveedo__61266BB9FCC80550");

            entity.Property(e => e.ProveedorId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PK__Reservas__C3993703F8F7F164");

            entity.Property(e => e.ReservaId).ValueGeneratedNever();

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas).HasConstraintName("FK__Reservas__Client__693CA210");

            entity.HasOne(d => d.Mesa).WithMany(p => p.Reservas).HasConstraintName("FK__Reservas__MesaID__6A30C649");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D115D6AD29");

            entity.Property(e => e.RolId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7989E14C97E");

            entity.Property(e => e.UsuarioId).ValueGeneratedNever();

            entity.HasOne(d => d.Empleado).WithMany(p => p.Usuarios).HasConstraintName("FK__Usuarios__Emplea__0E6E26BF");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios).HasConstraintName("FK__Usuarios__RolID__0F624AF8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
