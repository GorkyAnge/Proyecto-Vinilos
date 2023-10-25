//Gorky Palacios Mutis
using EjercicioEnClase2.Models;
using EjercicioEnClase2.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioEnClase2.Controllers
{
    public class ProductoController : Controller
    {
        // Configuración para realizar solicitudes al API
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5240";

        // Constructor del controlador
        public ProductoController()
        {
            // Inicializa un cliente HTTP con la URL base del API
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_apiBaseUrl)
            };
        }

        // Acción para mostrar una lista de productos
        public async Task<IActionResult> Index()
        {
            // Realiza una solicitud GET al API para obtener la lista de productos
            var productos = await _httpClient.GetFromJsonAsync<List<Producto>>("api/Producto");

            // Devuelve una vista que muestra los productos
            return View(productos);
        }

        // Acción para mostrar el formulario de creación de un producto
        public IActionResult Create()
        {
            return View();
        }

        // Acción para procesar la creación de un producto
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            // Realiza una solicitud POST al API para crear un nuevo producto
            await _httpClient.PostAsJsonAsync("api/Producto", producto);

            // Redirige al usuario a la lista de productos (acción "Index")
            return RedirectToAction("Index");
        }

        // Acción para mostrar los detalles de un producto
        public async Task<IActionResult> Details(int id)
        {
            // Realiza una solicitud GET al API para obtener
            //los detalles de un producto específico

            var producto = await _httpClient.GetFromJsonAsync<Producto>($"api/Producto/{id}");

            // Si se encuentra el producto, muestra una vista con los detalles
            //de lo contrario, redirige al usuario a la lista de productos

            if (producto != null) return View(producto);
            return RedirectToAction("Index");
        }

        // Acción para mostrar el formulario de edición de un producto
        public async Task<IActionResult> Edit(int id)
        {
            // Realiza una solicitud GET al API para obtener
            //un producto específico que se desea editar

            var producto = await _httpClient.GetFromJsonAsync<Producto>($"api/Producto/{id}");

            // Si se encuentra el producto, muestra una vista con 
            //el formulario de edición
            ///de lo contrario, redirige al usuario a la lista de productos

            if (producto != null) return View(producto);
            return RedirectToAction("Index");
        }

        // Acción para procesar la edición de un producto
        [HttpPost]
        public async Task<IActionResult> Edit(Producto producto)
        {
            // Realiza una solicitud PUT al API para actualizar
            //un producto con los datos proporcionados

            await _httpClient.PutAsJsonAsync($"api/Producto/{producto.Id}", producto);

            // Redirige al usuario a la lista de productos (acción "Index")
            return RedirectToAction("Index");
        }

        // Acción para eliminar un producto
        public async Task<IActionResult> Delete(int id)
        {
            // Realiza una solicitud DELETE al API para eliminar un producto específico
            await _httpClient.DeleteAsync($"api/Producto/{id}");

            // Redirige al usuario a la lista de productos (acción "Index")
            return RedirectToAction("Index");
        }
    }
}

