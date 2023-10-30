namespace EjercicioEnClase2.Models
{
    public class Compra
    {
        public int IdCarrito { get; set; }
        public int IdUsuario { get; set; }
        public List<Producto> ListaProductos { get; set; }
        public float Total { get; set; }
    }
}
