using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class DireccionEntrega
{
    public int IdDireccion { get; set; }

    public int? IdUsuario { get; set; }

    public string? Calle { get; set; }

    public string? Numero { get; set; }

    public string? Ciudad { get; set; }

    public string? CodigoPostal { get; set; }

    public virtual ICollection<CompraT> CompraTs { get; set; } = new List<CompraT>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
