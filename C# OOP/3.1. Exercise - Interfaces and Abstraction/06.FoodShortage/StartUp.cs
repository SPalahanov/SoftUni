using System.ComponentModel;
using System.Globalization;
using FoodShortage.Core;
using FoodShortage.Core.Interfaces;

namespace FoodShortage
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