using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class DetalleEntradum
{
    public int IdDetalleEntrada { get; set; }

    public int? IdCarritoEntrada { get; set; }

    public int? IdUbicacionEvento { get; set; }

    public decimal? Precio { get; set; }

    public virtual CarritoEntradum? IdCarritoEntradaNavigation { get; set; }

    public virtual UbicacionEvento? IdUbicacionEventoNavigation { get; set; }
}
