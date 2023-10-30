using EjercicioEnClase2.Models;
using EjercicioEnClase2.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioEnClase2.Controllers
{
    public class CarritoController : Controller
    {
        // Configuración para realizar solicitudes al API
        private readonly IAPICompra _apiCompra;

        // Constructor del controlador
        public CarritoController(IAPICompra apiCompra)
        {
            _apiCompra = apiCompra;
        }

        // GET: CarritoController
        public async Task<IActionResult> Detalles(int id)
        {
            var carrito = await _apiCompra.GetCarrito(id);
            if (carrito == null)
            {
                return NotFound();
            }
            return View(carrito);
        }

        //Crear un nuevo carrito (POST)
        [HttpPost]
        public async Task<IActionResult> Crear(Compra carrito)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _apiCompra.PostCarrito(carrito);
                if (resultado)
                {
                    return RedirectToAction("Detalles", new { id = carrito.IdCarrito });
                }
            }
            return View(carrito);
        }


        //Actualizar un carrito existente (PUT)
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Compra carrito)
        {
            if (id != carrito.IdCarrito)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var resultado = await _apiCompra.UpdateCarrito(id, carrito);
                if (resultado)
                {
                    return RedirectToAction("Detalles", new { id = carrito.IdCarrito });
                }
            }
            return View(carrito);
        }


        //Eliminar un carrito (DELETE)
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _apiCompra.DeleteCarrito(id);
            if (resultado)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }


        //Agregar un producto al carrito
        [HttpPost]
        public async Task<IActionResult> AgregarProducto(int idCarrito, Producto producto, int cantidad)
        {
            var resultado = await _apiCompra.AddProducto(idCarrito, producto, cantidad);
            if (resultado)
            {
                return RedirectToAction("Detalles", new { id = idCarrito });
            }
            // Gestiona el error adecuadamente.
            return BadRequest();
        }


        //Actualizar un producto en el carrito
        [HttpPost]
        public async Task<IActionResult> ActualizarProducto(int idCarrito, int idProducto, int cantidad)
        {
            var resultado = await _apiCompra.UpdateProducto(idCarrito, idProducto, cantidad);
            if (resultado)
            {
                return RedirectToAction("Detalles", new { id = idCarrito });
            }
            // Gestiona el error adecuadamente.
            return BadRequest();
        }


        //Eliminar un producto del carrito
        public async Task<IActionResult> EliminarProducto(int idCarrito, int idProducto)
        {
            var resultado = await _apiCompra.RemoveProducto(idCarrito, idProducto);
            if (resultado)
            {
                return RedirectToAction("Detalles", new { id = idCarrito });
            }
            // Gestiona el error adecuadamente.
            return BadRequest();
        }






    }
}
