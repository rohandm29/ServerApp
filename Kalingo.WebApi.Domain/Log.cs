using NLog;
using System;

namespace Kalingo.WebApi.Domain
{
    public class Log
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void Error(Exception e)
        {
            _logger.Error($"Error: GetUser() - {e.Message} \n {e.StackTrace} \n -------------------");
        }
    }
}
