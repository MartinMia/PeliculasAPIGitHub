 using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using PeliculasAPI.Entidades;
using PeliculasAPI.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [Route("api/generos")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class GenerosController :ControllerBase
    {
        //private readonly IRepositorio repositorio;
        //private readonly WeatherForecastController weatherForecastController;
        private readonly ILogger<GenerosController> logger;

        public GenerosController(ILogger<GenerosController> logger)
        {
            //this.repositorio = repositorio;
            //this.weatherForecastController = weatherForecastController;
            this.logger = logger;
        }

        [HttpGet] //apo/generos
        //[HttpGet("listado")]
        //[HttpGet("/listadogeneros")]
        //[ResponseCache(Duration = 60)]
        //[ServiceFilter(typeof(MiFiltroDeAccion))]
        public ActionResult<List<Genero>> Get()
        {
            //logger.LogInformation("Vamos a mostrar todos los géneros");
            //return repositorio.GetAll();
            return new List<Genero>() { new Genero() };   
        }

        //[HttpGet("guid")]
        //public ActionResult<Guid> GetGuid()
        //{
        //    return Ok(new
        //    {
        //        GUID_GenerosController = repositorio.ObtenerGuid(),
        //        GUID_WeatherForecastController = weatherForecastController.GetGUIDWeatherForecastController()
        //    });
        //}

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id)
        {

            //var genero = await repositorio.GetId(Id);

            //if(genero == null)
            //{

            //    throw new ApplicationException($"El género de ID {Id} no fue encontrado");
            //    logger.LogWarning($"No pudimos encontrar el género con id: {Id}");
            //    return NotFound();
            //}

            //return genero;

            throw new NotImplementedException();

        }

        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            //repositorio.CrearGenero(genero);
            //return NoContent();
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            //return NoContent();
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            //return NoContent();
            throw new NotImplementedException();
        }

    }
}
