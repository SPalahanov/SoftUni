using Log.ForU.ConsoleApp.Core;
using Log.ForU.ConsoleApp.CustomLayout;
using Log.ForU.Core.Appenders;
using Log.ForU.Core.Appenders.Interfaces;
using Log.ForU.Core.Enums;
using Log.ForU.Core.IO;
using Log.ForU.Core.Layout;
using Log.ForU.Core.Loggers;
using Log.ForU.Core.Loggers.Interfaces;
using Log.ForU.Core.Utils;

namespace Log.ForU.ConsoleApp
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}