using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.ForU.Core.Appenders.Interfaces;
using Log.ForU.Core.Enums;
using Log.ForU.Core.IO.Interfaces;
using Log.ForU.Core.Layout.Interfaces;
using Log.ForU.Core.Models;

namespace Log.ForU.Core.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel reportLevel = ReportLevel.Info)
            : base(layout, reportLevel)
        {
            LogFile = logFile;
        }

        public ILogFile LogFile { get; private set; }

        public override void AppendMessage(Message message)
        {
            string content =
                string.Format(Layout.Format, message.CreatedTime, message.ReportLevel, message.Text) + Environment.NewLine;

            File.AppendAllText(LogFile.FullPath, content);

            MessagesAppended++;
        }

        public override string ToString()
            => $"{base.ToString()}, File size: {LogFile.Size}";
    }
}
