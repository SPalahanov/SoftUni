using CollectionHierarchy.Core;
using CollectionHierarchy.Core.Interfaces;

namespace CollectionHierarchy
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