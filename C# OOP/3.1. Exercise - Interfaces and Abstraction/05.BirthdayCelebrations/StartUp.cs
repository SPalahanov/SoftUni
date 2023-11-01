using BirthdayCelebrations.Core;
using BirthdayCelebrations.Core.Interfaces;

namespace BirthdayCelebrations
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}