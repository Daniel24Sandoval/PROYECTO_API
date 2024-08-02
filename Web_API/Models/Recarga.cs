using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class Recarga
{
    public int IdRecarga { get; set; }

    public int? IdContacto { get; set; }

    public int? IdUsuario { get; set; }

    public string? NumeroDestino { get; set; }

    public decimal? Monto { get; set; }

    public virtual Contacto? IdContactoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
