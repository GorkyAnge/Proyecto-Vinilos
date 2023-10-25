using APIProductos.Data;
using APIProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {


        private readonly ApplicationDBContext _db;

        public ProductoController(ApplicationDBContext db)
        {
            _db = db;
        }


        // GET: api/<ProductoController>
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            List<Producto> productos = await _db.Productos.ToListAsync();
            return Ok(productos);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {

            Producto producto = await _db.Productos.FirstOrDefaultAsync(x => x.Id == Id);

            if (producto == null)
            {
                return BadRequest();
            }
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            var productoEncontrado = await _db.Productos.FirstOrDefaultAsync(p => p.Id == producto.Id);
            if (producto == null || productoEncontrado != null) return BadRequest();
            await _db.Productos.AddAsync(producto);
            await _db.SaveChangesAsync();
            return Ok(producto);

        }

        // PUT: api/Producto/5
        [HttpPut("{IdProducto}")]
        public async Task<ActionResult> Put(int IdProducto, [FromBody] Producto producto)
        {
            var productoEncontrado = await _db.Productos.FirstOrDefaultAsync(p => p.Id == IdProducto);
            if (productoEncontrado is null) return NotFound();

            productoEncontrado.Nombre = producto.Nombre ?? productoEncontrado.Nombre;
            productoEncontrado.Descripcion = producto.Descripcion ?? productoEncontrado.Nombre;
            productoEncontrado.Cantidad = producto.Cantidad;
            _db.Productos.Update(productoEncontrado);
            await _db.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Producto/5
        [HttpDelete("{IdProducto}")]
        public async Task<IActionResult> Delete(int IdProducto)
        {
            var producto = await _db.Productos.FirstOrDefaultAsync(p => p.Id == IdProducto);
            if (producto is null) return NotFound();
            _db.Productos.Remove(producto);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
