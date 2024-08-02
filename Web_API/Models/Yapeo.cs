using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class Yapeo
{
    public int IdYape { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdContacto { get; set; }

    public decimal? Monto { get; set; }

    public string? Estado { get; set; }

    public string? CodigoVerificacion { get; set; }

    public DateTime? FechaHora { get; set; }

    public virtual Contacto? IdContactoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
