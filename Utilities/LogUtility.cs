using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;

namespace Utilities
{
    public class LogUtility
    {
        public static void LogInit()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            var logConfigFileInfo = new FileInfo("log4net.Config");
            XmlConfigurator.Configure(logRepository, logConfigFileInfo);
        }

        public static ILog GetLogger<T>()
        {
            return LogManager.GetLogger(typeof(T));
        }
    }
}
