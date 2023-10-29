using EjercicioEnClase2.Models;
using EjercicioEnClase2.Service;
using EjercicioEnClase2.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioEnClase2.Controllers
{
    public class ProductoController : Controller
    {
        // Configuración para realizar solicitudes al API
        private readonly IAPIService _apiService;

        // Constructor del controlador
        public ProductoController(IAPIService apiService)
        {
            _apiService= apiService;
        }

        // Acción para mostrar una lista de productos
        public async Task<IActionResult> Index()
        {
            List<Producto> productos = await _apiService.GetProductos();
            return View(productos);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int IdProducto)
        {
            Producto producto = await _apiService.GetProducto(IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            Producto producto1 = await _apiService.PostProducto(producto);
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int IdProducto)
        {
            Producto producto = await _apiService.GetProducto(IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Producto producto)
        {
            Producto producto2 = await _apiService.GetProducto(producto.Id);
            if (producto2 != null)
            {
                Producto producto3 = await _apiService.PutProducto(producto.Id, producto);

                return RedirectToAction("Index");
            }
            return View();
        }


        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int IdProducto)
        {
            Boolean producto2 = await _apiService.DeleteProducto(IdProducto);
            if (producto2 != false)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}

