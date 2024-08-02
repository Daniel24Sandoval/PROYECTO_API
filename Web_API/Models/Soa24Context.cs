using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_API.Models;

public partial class Soa24Context : DbContext
{
    public Soa24Context()
    {
    }

    public Soa24Context(DbContextOptions<Soa24Context> options)
        : base(options)
    {
    }

    public virtual DbSet<CalificacionP> CalificacionPs { get; set; }

    public virtual DbSet<CarritoCompra> CarritoCompras { get; set; }

    public virtual DbSet<CarritoEntradum> CarritoEntrada { get; set; }

    public virtual DbSet<CategoriaEvento> CategoriaEventos { get; set; }

    public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; }

    public virtual DbSet<CompraE> CompraEs { get; set; }

    public virtual DbSet<CompraT> CompraTs { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<Credito> Creditos { get; set; }

    public virtual DbSet<Cuentum> Cuenta { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleEntradum> DetalleEntrada { get; set; }

    public virtual DbSet<DireccionEntrega> DireccionEntregas { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<FacturaPago> FacturaPagos { get; set; }

    public virtual DbSet<Historial> Historials { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Notificacion> Notificacions { get; set; }

    public virtual DbSet<Operadora> Operadoras { get; set; }

    public virtual DbSet<PagoServicio> PagoServicios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Recarga> Recargas { get; set; }

    public virtual DbSet<Tarjetum> Tarjeta { get; set; }

    public virtual DbSet<TipoEntradum> TipoEntrada { get; set; }

    public virtual DbSet<UbicacionEvento> UbicacionEventos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Yapeo> Yapeos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ENRIQUE;Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true;Initial Catalog=SOA24");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalificacionP>(entity =>
        {
            entity.HasKey(e => e.IdCalificacion).HasName("PK__Califica__00FC09277F7189FE");

            entity.ToTable("CalificacionP");

            entity.Property(e => e.IdCalificacion).HasColumnName("ID_calificacion");
            entity.Property(e => e.IdDetalle).HasColumnName("ID_detalle");
            entity.Property(e => e.Resena).HasColumnType("text");

            entity.HasOne(d => d.IdDetalleNavigation).WithMany(p => p.CalificacionPs)
                .HasForeignKey(d => d.IdDetalle)
                .HasConstraintName("FK__Calificac__ID_de__75A278F5");
        });

        modelBuilder.Entity<CarritoCompra>(entity =>
        {
            entity.HasKey(e => e.IdCarrito).HasName("PK__CarritoC__8AEEC703331C505D");

            entity.Property(e => e.IdCarrito).HasColumnName("ID_carrito");
            entity.Property(e => e.EstadoCompra)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.CarritoCompras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__CarritoCo__ID_us__693CA210");
        });

        modelBuilder.Entity<CarritoEntradum>(entity =>
        {
            entity.HasKey(e => e.IdCarritoEntrada).HasName("PK__CarritoE__F79C1F5F3ECEF3BB");

            entity.Property(e => e.IdCarritoEntrada).HasColumnName("ID_carrito_entrada");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.CarritoEntrada)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__CarritoEn__ID_us__07C12930");
        });

        modelBuilder.Entity<CategoriaEvento>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__37900156565A1188");

            entity.ToTable("Categoria_Evento");

            entity.Property(e => e.IdCategoria).HasColumnName("ID_categoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CategoriaProducto>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__37900156562E4157");

            entity.ToTable("Categoria_Producto");

            entity.Property(e => e.IdCategoria).HasColumnName("ID_categoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CompraE>(entity =>
        {
            entity.HasKey(e => e.IdCompraEntrada).HasName("PK__CompraE__E6AFE95B7CFE4D80");

            entity.ToTable("CompraE", tb => tb.HasTrigger("trg_AfterCompraE"));

            entity.Property(e => e.IdCompraEntrada).HasColumnName("ID_compra_entrada");
            entity.Property(e => e.IdCarritoEntrada).HasColumnName("ID_carrito_entrada");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCarritoEntradaNavigation).WithMany(p => p.CompraEs)
                .HasForeignKey(d => d.IdCarritoEntrada)
                .HasConstraintName("FK__CompraE__ID_carr__0E6E26BF");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.CompraEs)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__CompraE__ID_usua__0F624AF8");
        });

        modelBuilder.Entity<CompraT>(entity =>
        {
            entity.HasKey(e => e.IdCompraTienda).HasName("PK__CompraT__2E3C00F5312049C7");

            entity.ToTable("CompraT", tb => tb.HasTrigger("trg_AfterCompraT"));

            entity.Property(e => e.IdCompraTienda).HasColumnName("ID_compra_tienda");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdCarrito).HasColumnName("ID_carrito");
            entity.Property(e => e.IdDireccion).HasColumnName("ID_direccion");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.TotalCompra).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.CompraTs)
                .HasForeignKey(d => d.IdCarrito)
                .HasConstraintName("FK__CompraT__ID_carr__70DDC3D8");

            entity.HasOne(d => d.IdDireccionNavigation).WithMany(p => p.CompraTs)
                .HasForeignKey(d => d.IdDireccion)
                .HasConstraintName("FK__CompraT__ID_dire__72C60C4A");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.CompraTs)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__CompraT__ID_usua__71D1E811");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.IdContacto).HasName("PK__Contacto__2524182E0460BCCE");

            entity.ToTable("Contacto");

            entity.Property(e => e.IdContacto).HasColumnName("ID_contacto");
            entity.Property(e => e.IdOperadora).HasColumnName("ID_operadora");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SaldoPrepago)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Saldo_prepago");
            entity.Property(e => e.TipoLinea)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Tipo_linea");

            entity.HasOne(d => d.IdOperadoraNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.IdOperadora)
                .HasConstraintName("FK__Contacto__ID_ope__47DBAE45");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Contacto__ID_usu__48CFD27E");
        });

        modelBuilder.Entity<Credito>(entity =>
        {
            entity.HasKey(e => e.IdCredito).HasName("PK__Credito__A6EAB0C29A0DBAF5");

            entity.ToTable("Credito", tb => tb.HasTrigger("trg_AfterCredito"));

            entity.Property(e => e.IdCredito).HasColumnName("ID_credito");
            entity.Property(e => e.FechaFin).HasColumnName("Fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("Fecha_inicio");
            entity.Property(e => e.IdHistorial).HasColumnName("ID_historial");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TasaInteres)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Tasa_interes");

            entity.HasOne(d => d.IdHistorialNavigation).WithMany(p => p.Creditos)
                .HasForeignKey(d => d.IdHistorial)
                .HasConstraintName("FK__Credito__ID_hist__534D60F1");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Creditos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Credito__ID_usua__5441852A");
        });

        modelBuilder.Entity<Cuentum>(entity =>
        {
            entity.HasKey(e => e.IdCuenta).HasName("PK__Cuenta__8F81DCBFFEEB3FA8");

            entity.Property(e => e.IdCuenta).HasColumnName("ID_cuenta");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_empresa");
            entity.Property(e => e.IdTarjeta).HasColumnName("ID_tarjeta");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.Saldo)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK__Cuenta__ID_empre__4222D4EF");

            entity.HasOne(d => d.IdTarjetaNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdTarjeta)
                .HasConstraintName("FK__Cuenta__ID_tarje__4316F928");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Cuenta__ID_usuar__412EB0B6");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DetalleC__83B6061E1407E30B");

            entity.ToTable("DetalleCompra");

            entity.Property(e => e.IdDetalle).HasColumnName("ID_detalle");
            entity.Property(e => e.IdCarrito).HasColumnName("ID_carrito");
            entity.Property(e => e.IdProducto).HasColumnName("ID_producto");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdCarrito)
                .HasConstraintName("FK__DetalleCo__ID_ca__6C190EBB");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DetalleCo__ID_pr__6D0D32F4");
        });

        modelBuilder.Entity<DetalleEntradum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleEntrada).HasName("PK__DetalleE__43FA04C0FDAF46EF");

            entity.Property(e => e.IdDetalleEntrada).HasColumnName("ID_detalle_entrada");
            entity.Property(e => e.IdCarritoEntrada).HasColumnName("ID_carrito_entrada");
            entity.Property(e => e.IdUbicacionEvento).HasColumnName("ID_ubicacion_evento");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCarritoEntradaNavigation).WithMany(p => p.DetalleEntrada)
                .HasForeignKey(d => d.IdCarritoEntrada)
                .HasConstraintName("FK__DetalleEn__ID_ca__0A9D95DB");

            entity.HasOne(d => d.IdUbicacionEventoNavigation).WithMany(p => p.DetalleEntrada)
                .HasForeignKey(d => d.IdUbicacionEvento)
                .HasConstraintName("FK__DetalleEn__ID_ub__0B91BA14");
        });

        modelBuilder.Entity<DireccionEntrega>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__FF931E777AAF245D");

            entity.ToTable("Direccion_Entrega");

            entity.Property(e => e.IdDireccion).HasColumnName("ID_direccion");
            entity.Property(e => e.Calle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Codigo_postal");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.Numero)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.DireccionEntregas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Direccion__ID_us__66603565");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__Empresa__5237A6497C6B6BE1");

            entity.ToTable("Empresa");

            entity.Property(e => e.IdEmpresa).HasColumnName("ID_empresa");
            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.IdEvento).HasName("PK__Evento__443D766DFDEE3826");

            entity.ToTable("Evento");

            entity.Property(e => e.IdEvento).HasColumnName("ID_evento");
            entity.Property(e => e.Artistas).HasColumnType("text");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.IdCategoria).HasColumnName("ID_categoria");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_empresa");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Evento__ID_categ__7F2BE32F");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK__Evento__ID_empre__7E37BEF6");
        });

        modelBuilder.Entity<FacturaPago>(entity =>
        {
            entity.HasKey(e => e.IdFacturaPago).HasName("PK__FacturaP__17BA935C57F1AC6A");

            entity.ToTable("FacturaPago");

            entity.Property(e => e.IdFacturaPago).HasColumnName("ID_factura_pago");
            entity.Property(e => e.CodigoCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Codigo_cliente");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaPago).HasColumnName("Fecha_pago");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_empresa");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.MontoAPagar)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Monto_a_pagar");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.FacturaPagos)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK__FacturaPa__ID_em__5812160E");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.FacturaPagos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__FacturaPa__ID_us__59063A47");
        });

        modelBuilder.Entity<Historial>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__Historia__54D281D35868F776");

            entity.ToTable("Historial");

            entity.Property(e => e.IdHistorial).HasColumnName("ID_historial");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Historials)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Historial__ID_us__5070F446");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento).HasName("PK__Movimien__D2AC63C9D5B1AE41");

            entity.ToTable("Movimiento");

            entity.Property(e => e.IdMovimiento).HasColumnName("ID_movimiento");
            entity.Property(e => e.EntidadDestino)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Entidad_destino");
            entity.Property(e => e.EntidadOrigen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Entidad_origen");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdCompraEntrada).HasColumnName("ID_compra_entrada");
            entity.Property(e => e.IdCompraTienda).HasColumnName("ID_compra_tienda");
            entity.Property(e => e.IdCredito).HasColumnName("ID_credito");
            entity.Property(e => e.IdCuentaDestino).HasColumnName("ID_cuenta_destino");
            entity.Property(e => e.IdCuentaOrigen).HasColumnName("ID_cuenta_origen");
            entity.Property(e => e.IdPagoServicio).HasColumnName("ID_pago_servicio");
            entity.Property(e => e.IdRecarga).HasColumnName("ID_recarga");
            entity.Property(e => e.IdYape).HasColumnName("ID_yape");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nombre_servicio");

            entity.HasOne(d => d.IdCompraEntradaNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdCompraEntrada)
                .HasConstraintName("FK__Movimient__ID_co__1AD3FDA4");

            entity.HasOne(d => d.IdCompraTiendaNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdCompraTienda)
                .HasConstraintName("FK__Movimient__ID_co__18EBB532");

            entity.HasOne(d => d.IdCreditoNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdCredito)
                .HasConstraintName("FK__Movimient__ID_cr__17036CC0");

            entity.HasOne(d => d.IdCuentaDestinoNavigation).WithMany(p => p.MovimientoIdCuentaDestinoNavigations)
                .HasForeignKey(d => d.IdCuentaDestino)
                .HasConstraintName("FK__Movimient__ID_cu__1CBC4616");

            entity.HasOne(d => d.IdCuentaOrigenNavigation).WithMany(p => p.MovimientoIdCuentaOrigenNavigations)
                .HasForeignKey(d => d.IdCuentaOrigen)
                .HasConstraintName("FK__Movimient__ID_cu__1BC821DD");

            entity.HasOne(d => d.IdPagoServicioNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdPagoServicio)
                .HasConstraintName("FK__Movimient__ID_pa__17F790F9");

            entity.HasOne(d => d.IdRecargaNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdRecarga)
                .HasConstraintName("FK__Movimient__ID_re__19DFD96B");

            entity.HasOne(d => d.IdYapeNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdYape)
                .HasConstraintName("FK__Movimient__ID_ya__160F4887");
        });

        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK__Notifica__99BC7E5EA212AF42");

            entity.ToTable("Notificacion");

            entity.Property(e => e.IdNotificacion).HasColumnName("ID_notificacion");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NombreAccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nombre_accion");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nombre_servicio");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Notificacions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Notificac__ID_us__123EB7A3");
        });

        modelBuilder.Entity<Operadora>(entity =>
        {
            entity.HasKey(e => e.IdOperadora).HasName("PK__Operador__A30AEABC028A7550");

            entity.ToTable("Operadora");

            entity.Property(e => e.IdOperadora).HasColumnName("ID_operadora");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_empresa");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Operadoras)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK__Operadora__ID_em__3B75D760");
        });

        modelBuilder.Entity<PagoServicio>(entity =>
        {
            entity.HasKey(e => e.IdPagoServicio).HasName("PK__PagoServ__BBB2C47587DB3415");

            entity.ToTable("PagoServicio", tb => tb.HasTrigger("trg_AfterPagoServicio"));

            entity.Property(e => e.IdPagoServicio).HasColumnName("ID_pago_servicio");
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_pago");
            entity.Property(e => e.IdFacturaPago).HasColumnName("ID_factura_pago");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.MontoPagado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Monto_pagado");

            entity.HasOne(d => d.IdFacturaPagoNavigation).WithMany(p => p.PagoServicios)
                .HasForeignKey(d => d.IdFacturaPago)
                .HasConstraintName("FK__PagoServi__ID_fa__5CD6CB2B");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.PagoServicios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__PagoServi__ID_us__5DCAEF64");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__13C16394A28403F5");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasColumnName("ID_producto");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.IdCategoria).HasColumnName("ID_categoria");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_empresa");
            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Producto__ID_cat__6383C8BA");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK__Producto__ID_emp__628FA481");
        });

        modelBuilder.Entity<Recarga>(entity =>
        {
            entity.HasKey(e => e.IdRecarga).HasName("PK__Recarga__F71DFE6BB18905CC");

            entity.ToTable("Recarga", tb => tb.HasTrigger("trg_AfterRecarga"));

            entity.Property(e => e.IdRecarga).HasColumnName("ID_recarga");
            entity.Property(e => e.IdContacto).HasColumnName("ID_contacto");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NumeroDestino)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Numero_destino");

            entity.HasOne(d => d.IdContactoNavigation).WithMany(p => p.Recargas)
                .HasForeignKey(d => d.IdContacto)
                .HasConstraintName("FK__Recarga__ID_cont__787EE5A0");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Recargas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Recarga__ID_usua__797309D9");
        });

        modelBuilder.Entity<Tarjetum>(entity =>
        {
            entity.HasKey(e => e.IdTarjeta).HasName("PK__Tarjeta__1E709E6F89D532CF");

            entity.Property(e => e.IdTarjeta).HasColumnName("ID_tarjeta");
            entity.Property(e => e.Banco)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Clave)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDeCuenta)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TipoTarjeta)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoEntradum>(entity =>
        {
            entity.HasKey(e => e.IdTipoEntrada).HasName("PK__Tipo_Ent__B29DDC0852587C18");

            entity.ToTable("Tipo_Entrada");

            entity.Property(e => e.IdTipoEntrada).HasColumnName("ID_tipo_entrada");
            entity.Property(e => e.IdEvento).HasColumnName("ID_evento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.TipoEntrada)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("FK__Tipo_Entr__ID_ev__02084FDA");
        });

        modelBuilder.Entity<UbicacionEvento>(entity =>
        {
            entity.HasKey(e => e.IdUbicacionEvento).HasName("PK__Ubicacio__C7DA2FE00FC43936");

            entity.ToTable("UbicacionEvento");

            entity.Property(e => e.IdUbicacionEvento).HasColumnName("ID_ubicacion_evento");
            entity.Property(e => e.IdTipoEntrada).HasColumnName("ID_tipo_entrada");
            entity.Property(e => e.NAsiento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("N_asiento");

            entity.HasOne(d => d.IdTipoEntradaNavigation).WithMany(p => p.UbicacionEventos)
                .HasForeignKey(d => d.IdTipoEntrada)
                .HasConstraintName("FK__Ubicacion__ID_ti__04E4BC85");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__DF3D4252B2787C20");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Dniuser).HasColumnName("DNIUSER");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Yapeo>(entity =>
        {
            entity.HasKey(e => e.IdYape).HasName("PK__Yapeo__D98B44027DB1BCBA");

            entity.ToTable("Yapeo", tb => tb.HasTrigger("trg_AfterYapeo"));

            entity.Property(e => e.IdYape).HasColumnName("ID_yape");
            entity.Property(e => e.CodigoVerificacion)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Codigo_verificacion");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaHora)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_hora");
            entity.Property(e => e.IdContacto).HasColumnName("ID_contacto");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdContactoNavigation).WithMany(p => p.Yapeos)
                .HasForeignKey(d => d.IdContacto)
                .HasConstraintName("FK__Yapeo__ID_contac__4D94879B");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Yapeos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Yapeo__ID_usuari__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
