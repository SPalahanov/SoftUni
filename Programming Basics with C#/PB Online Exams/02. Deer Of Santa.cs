using System;

namespace _02.DeerOfSanta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dayOff = int.Parse(Console.ReadLine());
            int foodLeft = int.Parse(Console.ReadLine());
            double foodPerDayDeer1 = double.Parse(Console.ReadLine());
            double foodPerDayDeer2 = double.Parse(Console.ReadLine());
            double foodPerDayDeer3 = double.Parse(Console.ReadLine());

            double deer1Consum = foodPerDayDeer1 * dayOff;
            double deer2Consum = foodPerDayDeer2 * dayOff;
            double deer3Consum = foodPerDayDeer3 * dayOff;
            
            double neededFood = deer1Consum + deer2Consum + deer3Consum;

            if (neededFood <= foodLeft)
            {
                Console.WriteLine($"{Math.Floor(foodLeft - neededFood)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(neededFood - foodLeft)} more kilos of food are needed.");
            }
        }
    }
}
