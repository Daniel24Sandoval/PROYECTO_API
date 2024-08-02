using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class Contacto
{
    public int IdContacto { get; set; }

    public int? IdOperadora { get; set; }

    public int? IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public int? Numero { get; set; }

    public string? Pais { get; set; }

    public string? TipoLinea { get; set; }

    public decimal? SaldoPrepago { get; set; }

    public virtual Operadora? IdOperadoraNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Recarga> Recargas { get; set; } = new List<Recarga>();

    public virtual ICollection<Yapeo> Yapeos { get; set; } = new List<Yapeo>();
}
