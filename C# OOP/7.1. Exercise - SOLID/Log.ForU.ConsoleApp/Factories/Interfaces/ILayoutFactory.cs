using Log.ForU.Core.Layout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.ForU.ConsoleApp.Factories.Interfaces
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
