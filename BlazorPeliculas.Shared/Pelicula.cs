using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorPeliculas.Shared
{
    public class Pelicula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        [Required(ErrorMessage = "Campo vacio, ingresa un nombre")]
        public string? NombrePelicula {get; set;}

        [Required(ErrorMessage = "Campo vacio, ingresa un director")]
        public string? Director { get; set; }

        [Range(50, 500, ErrorMessage = "Rango de duración incorrecto")]
        public int Duracion { get; set; }
        public DateOnly FechaEstreno { get; set; }
    }
}
