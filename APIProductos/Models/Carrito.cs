using System.ComponentModel.DataAnnotations;

namespace APIProductos.Models
{
    public class Carrito
    {
        [Key]
        public int IdCarrito { get; set; }
        [Key]
        public int IdUsuario { get; set; }
        public List<Producto> ListaProductos { get; set; }
        public float Total { get; set; }
    }
}
