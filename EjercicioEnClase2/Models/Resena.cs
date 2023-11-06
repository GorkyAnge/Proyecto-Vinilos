using System.ComponentModel.DataAnnotations;

namespace EjercicioEnClase2.Models
{
    public class Resena
    {
        public int IdResena { get; set; }
        public int ViniloId { get; set; }
        public String Usuario { get; set; }
        public String Texto { get; set; }
    }
}
