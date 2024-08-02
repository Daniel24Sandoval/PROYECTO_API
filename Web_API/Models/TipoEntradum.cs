using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class TipoEntradum
{
    public int IdTipoEntrada { get; set; }

    public int? IdEvento { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public int? Capacidad { get; set; }

    public virtual Evento? IdEventoNavigation { get; set; }

    public virtual ICollection<UbicacionEvento> UbicacionEventos { get; set; } = new List<UbicacionEvento>();
}
