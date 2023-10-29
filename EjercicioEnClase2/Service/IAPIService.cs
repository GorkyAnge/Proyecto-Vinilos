using EjercicioEnClase2.Models;
namespace EjercicioEnClase2.Service
{
    public interface IAPIService
    {
        public Task<List<Producto>> GetProductos();

        public Task<Producto> GetProducto(int id);

        public Task<Producto> PostProducto(Producto producto);

        public Task<Producto> PutProducto(int idProducto,Producto producto);   
        public Task<Boolean> DeleteProducto(int idProducto);   

    }
}
