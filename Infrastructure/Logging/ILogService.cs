using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Logging
{
    public interface ILogService<T>
    {
        public void LogInfo(string info);
        public void LogWarning(string info);
        public void LogError(string info);
        public void LogCritical(string info);
    }
}
