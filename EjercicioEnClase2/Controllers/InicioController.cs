using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using EjercicioEnClase2.Models;
using EjercicioEnClase2.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioEnClase2.Controllers
{
    public class InicioController : Controller
    {
        // Configuración para realizar solicitudes al API
        private readonly IAPIServiceUsuario _apiServiceUsuario;


        public InicioController(IAPIServiceUsuario apiServiceUsuario)
        {
            _apiServiceUsuario = apiServiceUsuario;
        }

        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario usuario)
        {
            Usuario usuario_creado = await _apiServiceUsuario.SaveUsuario(usuario);
            if(usuario_creado.IdUsuario>0)
                return RedirectToAction("IniciarSesion", "Inicio");
            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            Usuario usuario_encontrado = await _apiServiceUsuario.GetUsuario(correo, clave);
            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }
            //List<Claim> claims = new List<Claim>();
            //{
            //    new Claim(ClaimTypes.Name, usuario_encontrado.NombreUsuario);
            //};

            //ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //AuthenticationProperties properties = new AuthenticationProperties()
            //{
            //    AllowRefresh = true
            //};
            //await HttpContext.SignInAsync(
            //    CookieAuthenticationDefaults.AuthenticationScheme,
            //    new ClaimsPrincipal(claimsIdentity),
            //    properties
            //    );
            
            if (usuario_encontrado.EsAdmin)
            {
                return RedirectToAction("Index", "VistaAdministrador");
            }

            return RedirectToAction("Index","VistaUsuario");

            
        }

        public IActionResult Inicio()
        {
            return View();
        }
    }
}



