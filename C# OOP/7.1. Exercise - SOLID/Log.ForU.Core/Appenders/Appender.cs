using Log.ForU.Core.Enums;
using Log.ForU.Core.Layout.Interfaces;
using Log.ForU.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.ForU.Core.Appenders.Interfaces;

namespace Log.ForU.Core.Appenders
{
    public abstract class Appender : IAppender

    {
        protected Appender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            Layout = layout;
            ReportLevel = reportLevel;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; protected set; }

        public abstract void AppendMessage(Message message);

        public override string ToString()
            => $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessagesAppended}";
    }
}
