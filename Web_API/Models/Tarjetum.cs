using System;
using System.Collections.Generic;

namespace Web_API.Models;

public partial class Tarjetum
{
    public int IdTarjeta { get; set; }

    public string? NumeroDeCuenta { get; set; }

    public string? Banco { get; set; }

    public string? TipoTarjeta { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public string? Clave { get; set; }

    public virtual ICollection<Cuentum> Cuenta { get; set; } = new List<Cuentum>();
}
