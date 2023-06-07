using System;

namespace P05.GodzillaVs.Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int actors = int.Parse(Console.ReadLine());
            double outfit = double.Parse(Console.ReadLine());

            double set = budget * 0.1;

            double outfitPrice = actors * outfit;

            if (actors < 150)
            {
                outfitPrice = outfitPrice;
            }
            else
            {
                outfitPrice -= outfitPrice * 0.1;
            }

            double price = set + outfitPrice;

            if (price <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {Math.Abs(budget - price):f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(budget - price):f2} leva more.");
            }
        }
    }
}
