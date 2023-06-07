using System;

namespace P07.Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int P = int.Parse(Console.ReadLine());
            double nPrice = N * 250;
            double mPrice = nPrice * 0.35 * M;
            double pPrice = nPrice * 0.1 * P;

            double price = nPrice + mPrice + pPrice;

            if (N > M)
            {
                price = price - price * 0.15;
            }
            else
            {
                price = price;
            }


            if (price <= budget)
            {
                Console.WriteLine($"You have {Math.Abs(budget - price):f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(budget - price):f2} leva more!");
            }
        }
    }
}
