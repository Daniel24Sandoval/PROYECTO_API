using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class DetalleCompra
{
    public int IdDetalle { get; set; }

    public int? IdCarrito { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<CalificacionP> CalificacionPs { get; set; } = new List<CalificacionP>();

    public virtual CarritoCompra? IdCarritoNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
