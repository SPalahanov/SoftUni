using System;
using System.Xml.Schema;

namespace _03.ExcursionCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double totalPrice = 0;

            double price = 0;

            if (season == "spring")
            {
                if (people <= 5)
                {
                    price = 50.00;
                }
                else if (people > 5)
                {
                    price = 48.00;
                }
            }
            else if (season == "summer")
            {
                if (people <= 5)
                {
                    price = 48.50;
                }
                else if (people > 5)
                {
                    price = 45.00;
                }
            }
            else if (season == "autumn")
            {
                if (people <= 5)
                {
                    price = 60.00;
                }
                else if (people > 5)
                {
                    price = 49.50;
                }
            }
            else if (season == "winter")
            {
                if (people <= 5)
                {
                    price = 86.00;
                }
                else if (people > 5)
                {
                    price = 85.00;
                }
            }

            if (season == "summer")
            {
                totalPrice = (price - price * 0.15) * people;
            }
            else if (season == "winter")
            {
                totalPrice = (price + price * 0.08) * people;
            }
            else
            {
                totalPrice = price * people;
            }

            Console.WriteLine($"{totalPrice:f2} leva.");
        }
    }
}
