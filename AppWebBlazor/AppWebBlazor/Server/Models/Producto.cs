using System;
using System.Collections.Generic;

namespace AppWebBlazor.Server.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public virtual ICollection<Detalleventa> Detalleventa { get; set; } = new List<Detalleventa>();
}
