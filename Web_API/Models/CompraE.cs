using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class CompraE
{
    public int IdCompraEntrada { get; set; }

    public int? IdCarritoEntrada { get; set; }

    public int? IdUsuario { get; set; }

    public decimal? Monto { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual CarritoEntradum? IdCarritoEntradaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
