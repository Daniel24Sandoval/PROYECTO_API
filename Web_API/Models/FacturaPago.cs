using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class FacturaPago
{
    public int IdFacturaPago { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdUsuario { get; set; }

    public string? CodigoCliente { get; set; }

    public decimal? MontoAPagar { get; set; }

    public DateOnly? FechaPago { get; set; }

    public string? Estado { get; set; }

    public virtual Empresa? IdEmpresaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<PagoServicio> PagoServicios { get; set; } = new List<PagoServicio>();
}
