using EjercicioEnClase2.Models;

namespace EjercicioEnClase2.Service
{
    public interface IAPIResena
    {
        public Task<Resena> GetProducto(int Id);
        public Task<Resena> PostResena(Resena resena);
        public Task<List<Resena>> GetResenas(int id);
    }

}
