using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class Movimiento
{
    public int IdMovimiento { get; set; }

    public int? IdYape { get; set; }

    public int? IdCredito { get; set; }

    public int? IdPagoServicio { get; set; }

    public int? IdCompraTienda { get; set; }

    public int? IdRecarga { get; set; }

    public int? IdCompraEntrada { get; set; }

    public int? IdCuentaOrigen { get; set; }

    public int? IdCuentaDestino { get; set; }

    public string? NombreServicio { get; set; }

    public string? EntidadOrigen { get; set; }

    public string? EntidadDestino { get; set; }

    public decimal? Monto { get; set; }

    public DateTime Fecha { get; set; }

    public virtual CompraE? IdCompraEntradaNavigation { get; set; }

    public virtual CompraT? IdCompraTiendaNavigation { get; set; }

    public virtual Credito? IdCreditoNavigation { get; set; }

    public virtual Cuentum? IdCuentaDestinoNavigation { get; set; }

    public virtual Cuentum? IdCuentaOrigenNavigation { get; set; }

    public virtual PagoServicio? IdPagoServicioNavigation { get; set; }

    public virtual Recarga? IdRecargaNavigation { get; set; }

    public virtual Yapeo? IdYapeNavigation { get; set; }
}
