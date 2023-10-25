using System.ComponentModel.DataAnnotations;

namespace EjercicioEnClase2.Models
{
    public class Producto
    {
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
