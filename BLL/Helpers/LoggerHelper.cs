using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace BLL.Helpers
{
    /// <summary>
    /// Performs logging operations using NLog.
    /// </summary>
    public static class LoggerHelper
    {
        static private readonly Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void WriteError(string message)
        {
            logger.Log(LogLevel.Error, message);
        }
    }
}
