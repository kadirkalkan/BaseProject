using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CrossCuttingConcerns.Logging.ElasticSearch
{
    public class ElasticLogger : ILoggerService
    {
        // todo 35-> Serilog, Serilog.Sinks.ElasticSearch ve Serilog.AspNetCore Library'lerini yüklüyoruz. Ve ILoggerService'i implemente Ediyoruz.
        private static ILogger _logger;

        public ElasticLogger(ILogger logger)
        {
            _logger = logger;
        }

        private static string GetStringFromObject(object logService)
        {
            return JsonConvert.SerializeObject(logService);
        }

        public void Info(object logService)
        {
            _logger.Information(GetStringFromObject(logService));
        }

        public void Debug(object logService)
        {
            _logger.Debug(GetStringFromObject(logService));
        }

        public void Warn(object logService)
        {
            _logger.Warning(GetStringFromObject(logService));
        }

        public void Fatal(object logService)
        {
            _logger.Fatal(GetStringFromObject(logService));
        }

        public void Error(object logService)
        {
            _logger.Error(GetStringFromObject(logService));
        }
    }
}
