using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Utilidades;
namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/peliculas")]

    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;

        public PeliculasController(ApplicationDbContext context,
            IMapper mapper,
            IAlmacenadorArchivos almacenadorArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        //Gracias Juanma!!!
    }
}
