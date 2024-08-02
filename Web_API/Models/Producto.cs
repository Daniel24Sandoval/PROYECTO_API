using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public string? Marca { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual CategoriaProducto? IdCategoriaNavigation { get; set; }

    public virtual Empresa? IdEmpresaNavigation { get; set; }
}
