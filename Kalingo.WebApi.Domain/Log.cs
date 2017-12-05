using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
