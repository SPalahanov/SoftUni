using System;
using System.Reflection.Metadata;

namespace P05.Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double price = 0;
            string destination = "";
            string type = "";


            if (budget <= 100)
            {
                if (season == "summer")
                {
                    type = "Camp";
                    price = budget * 0.3;
                }
                else if (season == "winter")
                {
                    type = "Hotel";
                    price = budget * 0.7;
                }
                Console.WriteLine($"Somewhere in Bulgaria");
                Console.WriteLine($"{type} - {price:f2}");
            }
            else if (budget > 100 && budget <= 1000)
            {
                if (season == "summer")
                {
                    type = "Camp";
                    price = budget * 0.4;
                }
                else if (season == "winter")
                {
                    type = "Hotel";
                    price = budget * 0.8;
                }
                Console.WriteLine($"Somewhere in Balkans");
                Console.WriteLine($"{type} - {price:f2}");
            }
            else if (budget > 1000)
            {
                if (season == "summer")
                {
                    type = "Hotel";
                    price = budget * 0.9;
                }
                else if (season == "winter")
                {
                    type = "Hotel";
                    price = budget * 0.9;
                }
                Console.WriteLine($"Somewhere in Europe");
                Console.WriteLine($"{type} - {price:f2}");
            }
        }
    }
}
