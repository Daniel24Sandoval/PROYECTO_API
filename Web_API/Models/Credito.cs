using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class Credito
{
    public int IdCredito { get; set; }

    public int? IdHistorial { get; set; }

    public int? IdUsuario { get; set; }

    public decimal? Monto { get; set; }

    public decimal? TasaInteres { get; set; }

    public int? Plazo { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public bool? Estado { get; set; }

    public virtual Historial? IdHistorialNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
