using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class Evento
{
    public int IdEvento { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? Hora { get; set; }

    public string? Ubicacion { get; set; }

    public string? Descripcion { get; set; }

    public string? Artistas { get; set; }

    public virtual CategoriaEvento? IdCategoriaNavigation { get; set; }

    public virtual Empresa? IdEmpresaNavigation { get; set; }

    public virtual ICollection<TipoEntradum> TipoEntrada { get; set; } = new List<TipoEntradum>();
}
