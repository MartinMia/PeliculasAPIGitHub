using System;
using PeliculasAPI.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Entidades
{
    public class Genero
    {
        public int id { get; set; }
            
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength:50)]
        //[PrimeraLetraMayuscula]
        public string Nom { get; set; }

    }
}
//No me funciona IntelliCode
//No me deja cambiar el nivel de advertencia
//Tampoco crear la clase Migrations