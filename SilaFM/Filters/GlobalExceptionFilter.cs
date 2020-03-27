using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Pras.Web.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public GlobalExceptionFilter(ILoggerFactory logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            this._logger = logger.CreateLogger("Global Exception Filter");
        }

        public void OnException(ExceptionContext context)
        {
            this._logger.LogError(context.Exception, "GlobalExceptionFilter");
        }
    }
}
