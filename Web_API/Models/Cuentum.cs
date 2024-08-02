using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class Cuentum
{
    public int IdCuenta { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdTarjeta { get; set; }

    public decimal? Saldo { get; set; }

    public virtual Empresa? IdEmpresaNavigation { get; set; }

    public virtual Tarjetum? IdTarjetaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Movimiento> MovimientoIdCuentaDestinoNavigations { get; set; } = new List<Movimiento>();

    public virtual ICollection<Movimiento> MovimientoIdCuentaOrigenNavigations { get; set; } = new List<Movimiento>();
}
