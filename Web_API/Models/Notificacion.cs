using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class Notificacion
{
    public int IdNotificacion { get; set; }

    public int? IdUsuario { get; set; }

    public string? NombreServicio { get; set; }

    public string? NombreAccion { get; set; }

    public decimal? Monto { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
