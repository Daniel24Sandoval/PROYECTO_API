using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class CategoriaProducto
{
    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
