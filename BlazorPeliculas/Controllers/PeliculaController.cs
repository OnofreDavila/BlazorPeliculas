using BlazorPeliculas.Context;
using BlazorPeliculas.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorPeliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        //---------------Inicializar context------------//
        private readonly PeliculaDBContext _context;

        public PeliculaController(PeliculaDBContext context)
        {
            _context = context;
        }
        //---------------------------------------------//
        //---------------------------------------------//
        //Peticion Http Get que conecta la tabla Peliculas
        [HttpGet("ConexionPeliculas")]
        public async Task<ActionResult<string>> GetConexionUsuarios()
        {
            try
            {
                var respuesta = await _context.Peliculas.ToListAsync();
                return "Conectado a la base de datos y a la tabla PELICULAS";
            }
            catch (Exception ex)
            {
                return "Error de conexion con PELICULAS";
            }

        }
        //---------------------------------------------//
        //Peticion Http Get que conecta con el servidor
        [HttpGet("ConexionServidor")]
        public async Task<ActionResult<string>> Conexion()
        {
            return "Conectado con el servidor";
        }
        //---------------------------------------------//


        //--------------------LISTAR PELICULAS-------------------------//
        [HttpGet("PeliculasListar")]
        public async Task<ActionResult<List<Pelicula>>> ListarPeliculas()
        {
            var res = await _context.Peliculas.ToListAsync();
            return res;
        }
        //--------------------------------------------------------------//


        //--------------------AGREGAR PELICULAS-------------------------//

        [HttpPost("PeliculaAgregar")]
        public async Task<ActionResult<string>> HandleCreatePelicula([FromBody] Pelicula pelicula)
        {
            await _context.Peliculas.AddAsync(pelicula);
            var res = await _context.SaveChangesAsync();

            if (res == 1) return Created();
            else return BadRequest();
        }

        //--------------------------------------------------------------//

        //--------------------ACTUALIZAR PELICULAS-------------------------//
        [HttpPut("pelicula/{id}")]
        public async Task<ActionResult<string>> ActualizarPelicula(int id, Pelicula pelicula)
        {
            var find = await _context.Peliculas.FindAsync(id);

            if (find == null) return NotFound();

            var res = await _context.Peliculas
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.NombrePelicula, pelicula.NombrePelicula)
                    .SetProperty(p => p.Director, pelicula.Director)
                    .SetProperty(p => p.Duracion, pelicula.Duracion)
                    .SetProperty(p => p.FechaEstreno, pelicula.FechaEstreno));
            if (res == 1) return Ok();
            else return BadRequest();
        }

        //--------------------------------------------------------------//

        //--------------------ELIMINAR PELICULAS-------------------------//
        [HttpDelete("pelicula/{id}")]
        public async Task<ActionResult<string>> HandleDeletePelicula([FromRoute] int id)
        {
            var find = await _context.Peliculas.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (find == 1) return Ok();
            else return BadRequest();
        }
        //--------------------------------------------------------------//
    }


}
