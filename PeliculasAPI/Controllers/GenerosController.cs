 using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeliculasAPI.Entidades;
using PeliculasAPI.Filtros;
using PeliculasAPI.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeliculasAPI.DTOS;
using AutoMapper;
using PeliculasAPI.Utilidades;

namespace PeliculasAPI.Controllers
{
    [Route("api/generos")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenerosController : ControllerBase
    {
        private readonly IRepositorio repositorio;
        private readonly WeatherForecastController weatherForecastController;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly ILogger<GenerosController> logger;

        public GenerosController(IRepositorio repositorio,
            WeatherForecastController weatherForecastController,
            ILogger<GenerosController> logger,
            ApplicationDbContext context,
            IMapper mapper)
        {
            this.repositorio = repositorio;
            this.weatherForecastController = weatherForecastController;
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        //[HttpGet] // api/generos
        //[HttpGet("listado")] // api/generos/listado
        //[HttpGet("/listadogeneros")] // /listadogeneros
        ////[ResponseCache(Duration = 60)]
        //[ServiceFilter(typeof(MiFiltroDeAccion))]
        //public ActionResult<List<Genero>> Get()
        //{
        //    logger.LogInformation("Vamos a mostrar los géneros");
        //    return repositorio.GetAll();
        //}

        [HttpGet("guid")] // api/generos/guid
        public ActionResult<Guid> GetGUID()
        {
            return Ok(new
            {
                GUID_GenerosController = repositorio.ObtenerGuid()
                //GUID_WeatherForecastController = weatherForecastController.ObtenerGUIDWeatherForecastController()
            });
        }

        [HttpGet] //api/generos
        public async Task<ActionResult<List<GeneroDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = context.Generos.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var generos = await queryable.OrderBy(x => x.Nom).Paginar(paginacionDTO).ToListAsync();
            return mapper.Map<List<GeneroDTO>>(generos);
        }


        [HttpGet("{Id:int}")] // api/generos/3/felipe
        public async Task<ActionResult<Genero>> Get(int Id, [FromHeader] string nombre)
        {

            logger.LogDebug($"Obteniendo un género por el id {Id}");

            var genero = await repositorio.GetId(Id);

            if (genero == null)
            {
                throw new ApplicationException($"El género de ID {Id} no fue encontrado");
                logger.LogWarning($"No pudimos encontrar el género de id {Id}");
                return NotFound();
            }

            //return "felipe";
            //return Ok("felipe");
            //return Ok(DateTime.Now);
            return genero;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            repositorio.CrearGenero(genero);
            return NoContent();
        }

        [HttpPut]
        public async Task <ActionResult> Put([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = mapper.Map<Genero>(generoCreacionDTO);
            context.Add(genero);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }

    }
}