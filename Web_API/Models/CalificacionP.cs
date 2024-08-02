using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class CalificacionP
{
    public int IdCalificacion { get; set; }

    public int? IdDetalle { get; set; }

    public string? Resena { get; set; }

    public virtual DetalleCompra? IdDetalleNavigation { get; set; }
}
