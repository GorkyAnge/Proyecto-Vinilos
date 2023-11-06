using EjercicioEnClase2.Models;
using EjercicioEnClase2.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioEnClase2.Controllers
{
    public class ResenaController : Controller
    {
        // Configuración para realizar solicitudes al API

        private readonly IAPIResena _apiResena;

        // Constructor del controlador
        public ResenaController(IAPIResena apiResena)
        {

            _apiResena = apiResena;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> CreateResena(Resena resena)
        {
            Resena resena1 = await _apiResena.PostResena(resena);
            return RedirectToAction("Create");
        }

        //Acción para mostrar las reseñas de un producto
        //[Route("Resena/DetailsReview/{id}")]
        public async Task<IActionResult> DetailsReview(int Id)
        {
                List<Resena> resenas = await _apiResena.GetResenas(Id);
                return View(resenas);
        }

        //Acción para agregar una reseña a un producto
        public IActionResult Create()
        {
                return View();
        }

        //[Route("Resena/DetailsReview")]
        //public IActionResult DetailsReview()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Comment(int Id)
        {
            Resena resena = await _apiResena.GetProducto(Id);

            if (resena != null)
            {
                return View(resena);
            }
            return RedirectToAction("DetailsReview");
        }
    }
}
