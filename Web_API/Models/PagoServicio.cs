using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class PagoServicio
{
    public int IdPagoServicio { get; set; }

    public int? IdFacturaPago { get; set; }

    public int? IdUsuario { get; set; }

    public decimal? MontoPagado { get; set; }

    public DateTime? FechaPago { get; set; }

    public virtual FacturaPago? IdFacturaPagoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
