using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class CategoriaEvento
{
    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
