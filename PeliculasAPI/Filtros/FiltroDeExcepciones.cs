using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Filtros
{
    public class FiltroDeExcepciones : ExceptionFilterAttribute
    {
        private readonly ILogger<FiltroDeExcepciones> logger;

        public FiltroDeExcepciones(ILogger<FiltroDeExcepciones> logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception, context.Exception.Message);
            base.OnException(context);
        }
    }
}
