using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class CompraT
{
    public int IdCompraTienda { get; set; }

    public int? IdCarrito { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdDireccion { get; set; }

    public decimal? TotalCompra { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual CarritoCompra? IdCarritoNavigation { get; set; }

    public virtual DireccionEntrega? IdDireccionNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
