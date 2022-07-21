using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Entidades
{
    public class Cines
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:200)]
        public string Nombre { get; set; }
        public Point Ubicacion { get; set; }

        public List<PeliculasCines> PeliculasCines { get; set; }
    }
}
