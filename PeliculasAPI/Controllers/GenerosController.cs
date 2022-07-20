 using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext context;

        public GenerosController(ILogger<GenerosController> logger,
            ApplicationDbContext context)
        {
            //this.repositorio = repositorio;
            //this.weatherForecastController = weatherForecastController;
            this.logger = logger;
            this.context = context;
        }

        [HttpGet] //api/generos
        public async Task<ActionResult<List<Genero>>> Get()
        {

            return await context.Generos.ToListAsync();        }

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
            
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task <ActionResult> Put([FromBody] Genero genero)
        {
            context.Add(genero);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            //return NoContent();
            throw new NotImplementedException();
        }

    }
}
