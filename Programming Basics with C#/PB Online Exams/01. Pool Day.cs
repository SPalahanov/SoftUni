using System;

namespace P01.PoolDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double entrance = double.Parse(Console.ReadLine());
            double sunbed = double.Parse(Console.ReadLine());
            double umbrella = double.Parse(Console.ReadLine());
             
            int sunbedCount = (int)Math.Ceiling(people * 0.75);
            int umbrellaCount = (int)Math.Ceiling(people / 2.0);

            double totalPrice = (people * entrance) + (umbrella * umbrellaCount) + (sunbed * sunbedCount);

            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
