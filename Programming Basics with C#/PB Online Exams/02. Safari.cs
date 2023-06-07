using System;

namespace P02.Safari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double fuelNeeded = double.Parse(Console.ReadLine());
            string dayOfWeek = Console.ReadLine();

            double fuelPrice = fuelNeeded * 2.10;
            double totalprice = fuelPrice + 100;
            if (dayOfWeek == "Saturday")
            {
                totalprice -= totalprice * 0.10;
            }
            else if (dayOfWeek == "Sunday")
            {
                totalprice -= totalprice * 0.20;
            }

            if (budget >= totalprice)
            {
                double moneyLeft = budget - totalprice;
                Console.WriteLine($"Safari time! Money left: {moneyLeft:f2} lv. ");
            }
            else
            {
                double moneyNeeded = totalprice - budget;
                Console.WriteLine($"Not enough money! Money needed: {moneyNeeded:f2} lv.");
            }

        }
    }
}
