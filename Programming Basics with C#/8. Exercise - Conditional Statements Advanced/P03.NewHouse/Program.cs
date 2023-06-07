using System;

namespace P03.NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double price = 0;

            if (type == "Roses")
            {
                if (quantity > 80)
                {
                    price = 5 - 5 * 0.1;
                }
                else
                {
                    price = 5;
                }
            }
            else if (type == "Dahlias")
            {
                if (quantity > 90)
                {
                    price = 3.80 - 3.80 * 0.15;
                }
                else
                {
                    price = 3.80;
                }
            }
            else if (type == "Tulips")
            {
                if (quantity > 80)
                {
                    price = 2.80 - 2.80 * 0.15;
                }
                else
                {
                    price = 2.80;
                }
            }
            else if (type == "Narcissus")
            {
                if (quantity < 120)
                {
                    price = 3 + 3 * 0.15;
                }
                else
                {
                    price = 3;
                }
            }
            else if (type == "Gladiolus")
            {
                if (quantity < 80)
                {
                    price = 2.50 + 2.50 * 0.2;
                }
                else
                {
                    price = 2.50;
                }
            }
            if (budget > (quantity * price))
            {
                Console.WriteLine($"Hey, you have a great garden with {quantity} {type} and {Math.Abs(budget - quantity * price):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(budget - quantity * price):f2} leva more.");
            }
        }
    }
}
