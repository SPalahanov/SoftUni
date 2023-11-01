using ExplicitInterfaces.Core;
using ExplicitInterfaces.Core.Interfaces;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}