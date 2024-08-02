using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int? Dniuser { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<CarritoCompra> CarritoCompras { get; set; } = new List<CarritoCompra>();

    public virtual ICollection<CarritoEntradum> CarritoEntrada { get; set; } = new List<CarritoEntradum>();

    public virtual ICollection<CompraE> CompraEs { get; set; } = new List<CompraE>();

    public virtual ICollection<CompraT> CompraTs { get; set; } = new List<CompraT>();

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();

    public virtual ICollection<Credito> Creditos { get; set; } = new List<Credito>();

    public virtual ICollection<Cuentum> Cuenta { get; set; } = new List<Cuentum>();

    public virtual ICollection<DireccionEntrega> DireccionEntregas { get; set; } = new List<DireccionEntrega>();

    public virtual ICollection<FacturaPago> FacturaPagos { get; set; } = new List<FacturaPago>();

    public virtual ICollection<Historial> Historials { get; set; } = new List<Historial>();

    public virtual ICollection<Notificacion> Notificacions { get; set; } = new List<Notificacion>();

    public virtual ICollection<PagoServicio> PagoServicios { get; set; } = new List<PagoServicio>();

    public virtual ICollection<Recarga> Recargas { get; set; } = new List<Recarga>();

    public virtual ICollection<Yapeo> Yapeos { get; set; } = new List<Yapeo>();
}
