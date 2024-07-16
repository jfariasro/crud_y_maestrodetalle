using AppWebBlazor.Server.Models;
using AppWebBlazor.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppWebBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProductoController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            var lista = new List<ProductoDTO>();

            foreach (var item in await _context.Productos.ToListAsync())
            {
                lista.Add(new ProductoDTO
                {
                    Idproducto = item.Idproducto,
                    Nombre = item.Nombre,
                    Precio = item.Precio
                });
            }

            return Ok(lista);
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] ProductoDTO productoDTO)
        {
            try
            {
                var producto = new Producto()
                {
                    Idproducto = productoDTO.Idproducto,
                    Nombre = productoDTO.Nombre,
                    Precio = productoDTO.Precio
                };
                await _context.Productos.AddAsync(producto);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, new { Valor = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult> Editar([FromRoute] int id, [FromBody] ProductoDTO productoDTO)
        {
            try
            {
                if (id != productoDTO.Idproducto)
                    return NotFound("No coincide");

                var producto = await _context.Productos.FindAsync(id);

                if (producto == null)
                    return NotFound("No encontrado");


                _context.Entry(producto).CurrentValues.SetValues(productoDTO);

                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, new { Valor = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            try
            {
                var productoDTO = await _context.Productos.FindAsync(id);

                if (productoDTO == null)
                    return NotFound("No encontrado");

                _context.Productos.Remove(productoDTO);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, new { Valor = true });
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

    }
}
