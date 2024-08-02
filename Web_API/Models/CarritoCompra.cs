using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class CarritoCompra
{
    public int IdCarrito { get; set; }

    public int? IdUsuario { get; set; }

    public string? EstadoCompra { get; set; }

    public virtual ICollection<CompraT> CompraTs { get; set; } = new List<CompraT>();

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
