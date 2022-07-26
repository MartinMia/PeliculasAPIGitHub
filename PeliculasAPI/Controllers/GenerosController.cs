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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
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

        [HttpGet] //api/generos

        public async Task<ActionResult<List<GeneroDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = context.Generos.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var generos = await queryable.OrderBy(x => x.Nom).Paginar(paginacionDTO).ToListAsync();
            return mapper.Map<List<GeneroDTO>>(generos);
        }

        [HttpGet("todos")]
        [AllowAnonymous]
        public async Task<ActionResult<List<GeneroDTO>>> Todos()
        {
            var generos = await context.Generos.OrderBy(x => x.Nom).ToListAsync();
            return mapper.Map<List<GeneroDTO>>(generos);
        }

        [HttpGet("guid")] // api/generos/guid
        public ActionResult<Guid> GetGUID()
        {
            return Ok(new
            {
                GUID_GenerosController = repositorio.ObtenerGuid()
                //GUID_WeatherForecastController = weatherForecastController.ObtenerGUIDWeatherForecastController()
            });
        }

        [HttpGet("{Id:int}")] 
        public async Task<ActionResult<GeneroDTO>> Get(int Id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(x => x.Id == Id);

            if(genero == null)
            {
                return NotFound();
            }

            return mapper.Map<GeneroDTO>(genero);

        }


        [HttpPost]
        public async Task <ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = mapper.Map<Genero>(generoCreacionDTO);
            context.Add(genero);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}")]   
        public async Task <ActionResult> Put(int Id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(x => x.Id == Id);

            if (genero == null)
            {
                return NotFound();
            }

            genero = mapper.Map(generoCreacionDTO, genero);
            await context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Generos.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Genero() {Id = id });

            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}