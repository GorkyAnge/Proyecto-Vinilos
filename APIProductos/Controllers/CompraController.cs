using APIProductos.Data;
using APIProductos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CompraController(ApplicationDBContext db)
        {
            _db = db;
        }
        // GET: CarritoController
        [HttpGet("{IdCarrito}")]
        public async Task<IActionResult> Get(int IdCarrito)
        {
            var compra = await _db.Compras.FindAsync(IdCarrito);

            if (compra == null)
                return NotFound();

            return Ok(compra);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetComprasByUsuario(int usuarioId)
        {
            var compras = await _db.Compras.Where(c => c.IdUsuario == usuarioId).ToListAsync();

            return Ok(compras);
        }

        // POST: CarritoController/Create
        [HttpPost]
        public async Task<IActionResult> CreateCompra([FromBody] Compra compra)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _db.Compras.Add(compra);
            await _db.SaveChangesAsync();

            return Ok(compra);
        }


        // PUT: CarritoController/Update/5
        [HttpPut("{IdCarrito}")]
        public async Task<IActionResult> UpdateCompra(int id, [FromBody] Compra compra)
        {
            if (id != compra.IdCarrito)
                return BadRequest();

            _db.Entry(compra).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Compras.Any(e => e.IdCarrito == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }


        // DELETE: CarritoController/Delete/5
        [HttpDelete("{IdCarrito}")]
        public async Task<IActionResult> Delete(int IdCarrito)
        {
            var compra = await _db.Compras.FindAsync(IdCarrito);
            if (compra == null)
                return NotFound();

            _db.Compras.Remove(compra);
            await _db.SaveChangesAsync();

            return NoContent();
        }

    }
}
