using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.ForU.Core.Loggers.Interfaces
{
    public interface ILogger
    {
        void Info(string dateTime, string message);
        void Warning(string dateTime, string wwe);
        void Error(string dateTime, string wwe);
        void Critical(string dateTime, string wwe);
        void Fatal(string dateTime, string wwe);
    }
}
