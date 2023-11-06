using APIProductos.Data;
using APIProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResenaController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public ResenaController(ApplicationDBContext db)
        {
            _db = db;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var resena = await _db.Resenas.FirstOrDefaultAsync(x => x.IdResena == id);

            if (resena == null)
                return NotFound();

            return Ok(resena);
        }



        [HttpGet("/Resena/{productoId}")]
        public async Task<IActionResult> GetListByProduct(int productoId)
        {
            var resenas = await _db.Resenas.Where(r => r.ViniloId == productoId).ToListAsync();

            if (resenas == null || resenas.Count == 0)
                return NotFound();

            return Ok(resenas);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Resena resena)
        {
            var resenaEncontrada = await _db.Productos.FirstOrDefaultAsync(p => p.Id == resena.IdResena);
            if (resena == null || resenaEncontrada != null) return BadRequest();

            await _db.Resenas.AddAsync(resena);
            await _db.SaveChangesAsync();

            return Ok();
        }








        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarResena(int id, [FromBody] Resena resena)
        {
            if (id != resena.IdResena)
                return BadRequest();

            _db.Entry(resena).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Resenas.Any(e => e.IdResena == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarResena(int id)
        {
            var resena = await _db.Resenas.FindAsync(id);

            if (resena == null)
                return NotFound();

            _db.Resenas.Remove(resena);
            await _db.SaveChangesAsync();

            return NoContent();
        }


    }
}
