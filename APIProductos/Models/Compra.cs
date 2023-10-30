using System.ComponentModel.DataAnnotations;

namespace APIProductos.Models
{
    public class Compra
    {
        [Key]
        public int IdCarrito { get; set; }
        public int IdUsuario { get; set; }
        public List<Producto> ListaProductos { get; set; }
        public float Total { get; set; }
    }
}
