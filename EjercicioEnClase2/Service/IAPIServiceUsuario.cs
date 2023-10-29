using EjercicioEnClase2.Models;

namespace EjercicioEnClase2.Service
{
    public interface IAPIServiceUsuario
    {
        public Task<Usuario > GetUsuario(string correo, string clave);
        public Task<Usuario > SaveUsuario(Usuario usuario);
    }
}
