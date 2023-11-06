using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APIProductos.Models
{
    public class Resena
    {
        [Key]
        public int IdResena { get; set; }
        [Required]
        public int ViniloId { get; set; }
        [Required]
        public String Usuario { get; set; }
        [Required]
        public String Texto { get; set; }
    }
}
