using EjercicioEnClase2.Models;

namespace EjercicioEnClase2.Service
{
    public interface IAPICompra
    {
        //Obtener el carrito por ID
        public Task<Compra> GetCarrito(int IdCarrito);
        //Crear un nuevo carrito
        public Task<bool> PostCarrito(Compra carrito);
        //Actualizar un carrito existente
        public Task<bool> UpdateCarrito(int IdCarrito, Compra carrito);
        //Eliminar un carrito
        public Task<bool> DeleteCarrito(int IdCarrito);
        //Agregar un producto al carrito
        public Task<bool> AddProducto(int IdCarrito, Producto producto, int Cantidad);
        //Actualizar un producto en el carrito
        public Task<bool> UpdateProducto(int IdCarrito, int Id, int Cantidad);
        //Eliminar un producto del carrito
        public Task<bool> RemoveProducto(int IdCarrito, int Id);
    }
}
