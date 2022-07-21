using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.DTOS
{
    public class ActorDTO
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }

        public string Biografia { get; set; }

        public DateTime FechaNac { get; set; }

        public string Foto { get; set; }
    }
}
