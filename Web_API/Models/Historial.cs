using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class Historial
{
    public int IdHistorial { get; set; }

    public int? IdUsuario { get; set; }

    public bool? Calificacion { get; set; }

    public virtual ICollection<Credito> Creditos { get; set; } = new List<Credito>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
