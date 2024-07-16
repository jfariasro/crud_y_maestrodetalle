using AppWebBlazor.Server.Models;
using AppWebBlazor.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppWebBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly MyDbContext _context;

        public VentaController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO ventaDTO)
        {
            try
            {
                var venta = new Venta();
                venta.Cliente = ventaDTO.Cliente;
                venta.Total = ventaDTO.Total;

                var detalle = new List<Detalleventa>();

                foreach (var item in ventaDTO.Detalleventa)
                {
                    detalle.Add(new Detalleventa
                    {
                        Idproducto = item.Producto.Idproducto,
                        Cantidad = item.Cantidad,
                        Subtotal = item.Subtotal,
                    });
                }

                venta.Detalleventa = detalle;

                await _context.Venta.AddAsync(venta);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, new { Valor = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
