using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.DTOS
{
    public class PeliculaCreacionDTO
    {
        [Required]
        [StringLength(maximumLength: 20)]
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string Trailer { get; set; }
        public bool EnCines { get; set; }

        public DateTime Fecha { get; set; }
        public IFormFile Poster { get; set; }
    }
}
