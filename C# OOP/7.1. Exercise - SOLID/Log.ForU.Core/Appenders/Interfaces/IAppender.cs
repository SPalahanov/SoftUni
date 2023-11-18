using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.ForU.Core.Enums;
using Log.ForU.Core.Layout.Interfaces;
using Log.ForU.Core.Models;

namespace Log.ForU.Core.Appenders.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        int MessagesAppended { get; }

        void AppendMessage(Message message);
    }
}