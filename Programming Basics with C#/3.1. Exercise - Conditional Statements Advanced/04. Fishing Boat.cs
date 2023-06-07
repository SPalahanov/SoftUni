using System;
using System.Net.NetworkInformation;

namespace P04.FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());

            double price = 0;

            if (season == "Summer")
            {
                price = 4200;
                if (people <= 6)
                {
                    price = price - price * 0.1;
                }
                else if (people > 7 && people <= 11)
                {
                    price = price - price * 0.15;
                }
                else if (people > 12)
                {
                    price = price - price * 0.25;
                }
            }
            else if (season == "Autumn")
            {
                price = 4200;
                if (people <= 6)
                {
                    price =  price - price * 0.1;
                }
                else if (people > 7 && people <= 11)
                {
                    price = price - price * 0.15;
                }
                else if (people > 12)
                {
                    price = price - price * 0.25;
                }
            }
            else if (season == "Spring")
            {
                price = 3000;
                if (people <= 6)
                {
                    price = price - price * 0.1;
                }
                else if (people > 7 && people <= 11)
                {
                    price = price - price * 0.15;
                }
                else if (people > 12)
                {
                    price = price - price * 0.25;
                }
            }
            else if (season == "Winter")
            {
                price = 2600;
                if (people <= 6)
                {
                    price = price - price * 0.1;
                }
                else if (people > 7 && people <= 11)
                {
                    price = price - price * 0.15;
                }
                else if (people > 12)
                {
                    price = price - price * 0.25;
                }
            }

            if (people % 2 == 0 && season != "Autumn")
            {
                price = price - price * 0.05;
            }

            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {Math.Abs(budget - price):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(budget - price):f2} leva.");
            }
        }
    }
}
