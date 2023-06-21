using Microsoft.AspNetCore.Http;

namespace Logging.Middleware
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Logger.Logger _logger;

        public LoggerMiddleware(RequestDelegate next, Logger.Logger logger)
        {
            _next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                this._logger.Error(e.Message, e);
                throw;
            }
            
        }
    }
}
