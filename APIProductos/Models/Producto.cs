using System.ComponentModel.DataAnnotations;

namespace APIProductos.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public float Precio { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Cantidad { get; set; }
    }
}
