using System;
using System.Collections.Generic;

namespace AppWebBlazor.Server.Models;

public partial class Venta
{
    public int Idventa { get; set; }

    public string? Cliente { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<Detalleventa> Detalleventa { get; set; } = new List<Detalleventa>();
}
