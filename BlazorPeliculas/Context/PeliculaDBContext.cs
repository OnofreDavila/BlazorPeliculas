using BlazorPeliculas.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorPeliculas.Context
{
    public class PeliculaDBContext : DbContext
    {

        //------Inicializa la instancia de la clase DBContext-----//
        public PeliculaDBContext(DbContextOptions<PeliculaDBContext> options) : base(options)
        {
        }
        //---------------Model-----------------------------//
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //------------------------------------------------//

        //------Referencia entre la clase Pelicula y la tabla Peliculas-------//
        public DbSet<Pelicula> Peliculas { get; set; }
        //------------------------------------------------//
    }
}
