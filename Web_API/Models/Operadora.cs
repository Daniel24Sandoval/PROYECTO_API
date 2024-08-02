using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class Operadora
{
    public int IdOperadora { get; set; }

    public int? IdEmpresa { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();

    public virtual Empresa? IdEmpresaNavigation { get; set; }
}
