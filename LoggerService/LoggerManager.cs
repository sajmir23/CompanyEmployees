using Contracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILoggerManager logger = LogManager.GetCurrentClassLogger();
        public LoggerManager() 
        {
        }
        public void LogDebug(string message) => logger.LogDebug(message);
        public void LogError(string message) => logger.LogError(message);
        public void LogInfo(string message) => logger.LogInfo(message);
        public void LogWarn(string message) => logger.LogWarn(message);

    }
}
