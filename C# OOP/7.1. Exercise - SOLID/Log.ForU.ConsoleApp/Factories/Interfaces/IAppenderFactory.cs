using Log.ForU.Core.Appenders.Interfaces;
using Log.ForU.Core.Enums;
using Log.ForU.Core.IO.Interfaces;
using Log.ForU.Core.Layout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.ForU.ConsoleApp.Factories.Interfaces
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel, ILogFile logFile = null);
    }
}
