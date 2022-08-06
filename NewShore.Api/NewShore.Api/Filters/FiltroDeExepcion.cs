using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace NewShore.Api.Filters
{
    public class FiltroDeExepcion : ExceptionFilterAttribute
    {
        private readonly ILogger<FiltroDeExepcion> logger;

        public FiltroDeExepcion(ILogger<FiltroDeExepcion> logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception.Message);

            base.OnException(context);
        }
    }
}
