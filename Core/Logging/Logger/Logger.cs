using Microsoft.Extensions.Configuration;
using Serilog;

namespace Logging.Logger
{
    public class Logger
    {
        private readonly ILogger _logger;

        public Logger(IConfiguration configuration)
        {
            var path = configuration.GetSection("Logger")["FilePath"];
            var config = new LoggerConfiguration().WriteTo.File(path);
            this._logger = config.CreateLogger();
        }

        public void Information(string messageTemplate, params object[] args)
        {
            this._logger.Information(messageTemplate, args);
        }

        public void Error(string messageTemplate, Exception e)
        {
            this._logger.Error(messageTemplate, e);
        }
    }
}
