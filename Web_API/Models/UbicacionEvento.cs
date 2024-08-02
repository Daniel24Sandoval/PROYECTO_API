using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class UbicacionEvento
{
    public int IdUbicacionEvento { get; set; }

    public int? IdTipoEntrada { get; set; }

    public string? NAsiento { get; set; }

    public virtual ICollection<DetalleEntradum> DetalleEntrada { get; set; } = new List<DetalleEntradum>();

    public virtual TipoEntradum? IdTipoEntradaNavigation { get; set; }
}
