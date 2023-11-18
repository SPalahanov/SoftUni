using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.ForU.ConsoleApp.CustomLayout;
using Log.ForU.ConsoleApp.Factories.Interfaces;
using Log.ForU.Core.Appenders;
using Log.ForU.Core.Layout;
using Log.ForU.Core.Layout.Interfaces;

namespace Log.ForU.ConsoleApp.Factories
{
    public class LayoutFactory :ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            switch (type)
            {
                case "XmlLayout":
                    return new XmlLayout();
                case "SimpleLayout":
                    return new SimpleLayout();
                default:
                    throw new InvalidOperationException("Invalid layout type");
            }
        }
    }
}
