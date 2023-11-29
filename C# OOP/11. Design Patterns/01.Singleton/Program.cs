using Singleton.Models;

namespace Singleton
{
    public class Program
    {
        static void Main()
        {
            var db = SingletonDataContainer.Instance;

            Console.WriteLine(db.GetPopulation("Washington, D.C."));

            var db2 = SingletonDataContainer.Instance;

            Console.WriteLine(db.GetPopulation("London"));

        }
    }
}