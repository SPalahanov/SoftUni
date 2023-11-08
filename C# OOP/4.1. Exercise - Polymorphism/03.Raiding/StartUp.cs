using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.Fabric;
using Raiding.Fabric.Interfaces;
using Raiding.IO;
using Raiding.IO.Interfaces;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IHeroFactory heroFactory = new HeroFactory();
            
            IEngine engine = new Engine(reader, writer, heroFactory);

            engine.Run();
        }
    }
}