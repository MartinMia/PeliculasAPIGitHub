using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.DTOS;
using PeliculasAPI.Entidades;
using PeliculasAPI.Utilidades;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/peliculas")]

    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "peliculas";

        public PeliculasController(ApplicationDbContext context,
            IMapper mapper,
            IAlmacenadorArchivos almacenadorArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        //Gracias Juanma!!!

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] PeliculaCreacionDTO peliculaCreacionDTO)
        {
            var pelicula = mapper.Map<Pelicula>(peliculaCreacionDTO);

            if (peliculaCreacionDTO.Poster != null)
            {
                pelicula.Poster = await almacenadorArchivos.EditarArchivo(contenedor, peliculaCreacionDTO.Poster, pelicula.Poster);
            }

            EscribirOrdenActores(pelicula);

            context.Add(pelicula);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private void EscribirOrdenActores(Pelicula peliculas)
        {
            if (peliculas.PeliculasActores != null)
            {
                for (int i = 0; i < peliculas.PeliculasActores.Count; i++)
                {
                    peliculas.PeliculasActores[i].Orden = i;
                }
            }
        }
    }
}
