using APIProductos.Data;
using APIProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {

        //Crear variable solo de lectura que es solo una referencia a la BDD
        private readonly ApplicationDBContext _db;

        //Constructor
        public UsuarioController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(string correo, string clave)
        {

            Usuario usuario_encontrado = await _db.Usuarios.Where(x => x.Correo == correo && x.Contrasena == clave).FirstOrDefaultAsync();

            if (usuario_encontrado == null)
            {
                return BadRequest();
            }
            return Ok(usuario_encontrado);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            _db.Usuarios.Add(usuario);
            await _db.SaveChangesAsync();
            return Ok(usuario);
            
        }
    }
}
