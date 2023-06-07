using System;

namespace P04.Club
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double target = double.Parse(Console.ReadLine());

            double currentSum = 0;

            string cocktailName;
            while ((cocktailName = Console.ReadLine()) != "Party!")
            {
                int cocktailCount = int.Parse(Console.ReadLine());

                double cocktailPrice = cocktailName.Length * cocktailCount;
                if (cocktailPrice % 2 != 0)
                {
                    cocktailPrice -= cocktailPrice * 0.25;
                }

                currentSum += cocktailPrice;
                if (currentSum >= target)
                {
                    break;
                }
            }

            if (currentSum >= target)
            {
                Console.WriteLine("Target acquired.");
            }
            else
            {
                double moneyNeeded = target - currentSum;
                Console.WriteLine($"We need {moneyNeeded:f2} leva more.");
            }

            Console.WriteLine($"Club income - {currentSum:f2} leva.");
        }
    }
}
