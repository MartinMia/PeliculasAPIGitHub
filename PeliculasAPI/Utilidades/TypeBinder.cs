
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Utilidades
{
    public class TypeBinder : IModelBinder 
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var nombrePropiedad = bindingContext.ModelName;
            var valor = bindingContext.ValueProvider.GetValue(nombrePropiedad);

            if (valor == ValueProviderResult.None)
            {
                
            }

            //try
            //{
            //    var ValorDescerializado = JsonConvert;
            //}
            return Task.CompletedTask;
        }
    }
}
