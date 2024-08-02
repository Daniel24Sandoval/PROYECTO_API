using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class Empresa
{
    public int IdEmpresa { get; set; }

    public string? Nombre { get; set; }

    public string? Categoria { get; set; }

    public virtual ICollection<Cuentum> Cuenta { get; set; } = new List<Cuentum>();

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual ICollection<FacturaPago> FacturaPagos { get; set; } = new List<FacturaPago>();

    public virtual ICollection<Operadora> Operadoras { get; set; } = new List<Operadora>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
