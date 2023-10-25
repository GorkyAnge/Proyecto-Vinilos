using APIProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Data
{
    public class ApplicationDBContext :DbContext
    {

        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options 
            ) : base( options ) { }
            
        
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(

                new Producto
                {
                    Id =1,
                    Nombre="Producto1",
                    Descripcion="Desc1",
                    Cantidad=13
                }


                );
        }
    }
}
