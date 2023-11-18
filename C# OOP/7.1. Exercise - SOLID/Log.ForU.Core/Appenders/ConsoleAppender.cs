using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.ForU.Core.Appenders.Interfaces;
using Log.ForU.Core.Enums;
using Log.ForU.Core.Layout.Interfaces;
using Log.ForU.Core.Models;

namespace Log.ForU.Core.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
            : base(layout, reportLevel)
        {
        }

        public override void AppendMessage(Message message)
        {
            Console.WriteLine(string.Format(Layout.Format, message.CreatedTime, message.ReportLevel, message.Text));

            MessagesAppended++;
        }
    }
}
