using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class CarritoEntradum
{
    public int IdCarritoEntrada { get; set; }

    public int? IdUsuario { get; set; }

    public decimal? Total { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<CompraE> CompraEs { get; set; } = new List<CompraE>();

    public virtual ICollection<DetalleEntradum> DetalleEntrada { get; set; } = new List<DetalleEntradum>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
