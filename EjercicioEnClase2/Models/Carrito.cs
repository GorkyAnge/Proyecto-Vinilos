namespace EjercicioEnClase2.Models
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public int IdUsuario { get; set; }
        public List<Producto> ListaProductos { get; set; }
        public float Total { get; set; }
    }
}
