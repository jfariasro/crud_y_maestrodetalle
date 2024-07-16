using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWebBlazor.Shared
{
    public class DetalleventaDTO
    {
        public int? Cantidad { get; set; }

        public decimal? Subtotal { get; set; }

        public virtual ProductoDTO? Producto { get; set; }
    }
}
