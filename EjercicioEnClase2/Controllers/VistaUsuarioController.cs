//Gorky Palacios Mutis
using EjercicioEnClase2.Models;
using EjercicioEnClase2.Service;
using EjercicioEnClase2.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioEnClase2.Controllers
{
    public class VistaUsuarioController : Controller
    {
        // Configuración para realizar solicitudes al API

        private readonly IAPIService _apiService;



        // Constructor del controlador
        public VistaUsuarioController(IAPIService apiService)
        {

            _apiService = apiService;
        }
        public IActionResult Carrito()
        {
            // Puedes implementar la lógica para mostrar el contenido del carrito de compras aquí
            // Por ejemplo, obtendrías los productos agregados al carrito y los mostrarías en la vista "Carrito.cshtml".

            return View(); // Esto renderizará la vista "Carrito.cshtml"
        }

        // Acción para mostrar una lista de productos
        public async Task<IActionResult> Index(string buscar)
        {
            List<Producto> productos;

            if (!string.IsNullOrEmpty(buscar))
            {
                // Realiza una búsqueda de productos por nombre y filtra la lista
                productos = await _apiService.BuscarProductosPorNombre(buscar);
            }
            else
            {
                // Si no se proporciona un término de búsqueda, obtén todos los productos
                productos = await _apiService.GetProductos();
            }

            return View(productos);
        }



        // Acción para mostrar los detalles de un producto
        public async Task<IActionResult> Details(int id)
        {
            Producto producto = await _apiService.GetProducto(id);

            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }
    }
}

