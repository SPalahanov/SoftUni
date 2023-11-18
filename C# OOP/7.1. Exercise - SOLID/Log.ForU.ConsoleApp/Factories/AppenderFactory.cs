using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.ForU.ConsoleApp.Factories.Interfaces;
using Log.ForU.Core.Appenders;
using Log.ForU.Core.Appenders.Interfaces;
using Log.ForU.Core.Enums;
using Log.ForU.Core.IO.Interfaces;
using Log.ForU.Core.Layout.Interfaces;

namespace Log.ForU.ConsoleApp.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel, ILogFile logFile = null)
        {
            switch (type)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout, reportLevel);
                case "FileAppender":
                    return new FileAppender(layout, logFile, reportLevel);
                default: 
                    throw new InvalidOperationException("Invalid appender type");
            }
        }
    }
}
