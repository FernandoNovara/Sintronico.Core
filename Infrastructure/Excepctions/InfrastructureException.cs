using Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Excepctions
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException() : base() { }

        public InfrastructureException(string message, ILogService<LogService> logService) : base(message)
        {
            logService.LogError($"Infrastructure - {message}");
        }

        public InfrastructureException(string message, ILogService<LogService> logService, Exception innerException)
            : base(message, innerException)
        {
            logService.LogError($"Infrastructure - {message} - [{innerException.Message}] - [{innerException.StackTrace}]");
        }
    }
}
