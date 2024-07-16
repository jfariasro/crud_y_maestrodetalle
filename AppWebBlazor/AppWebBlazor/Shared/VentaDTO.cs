using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWebBlazor.Shared
{
    public class VentaDTO
    {
        public string? Cliente { get; set; }

        public decimal? Total { get; set; }

        public virtual ICollection<DetalleventaDTO> Detalleventa { get; set; }
    }
}
