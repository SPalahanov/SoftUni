using Console = System.Console;

namespace _01._Burger_Bus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCities = int.Parse(Console.ReadLine());

            double totalProfit = 0;

            double cityProfit = 0;
            for (int i = 1; i <= numberOfCities; i++)
            {
                string nameOfCity = Console.ReadLine();
                double moneyErned = double.Parse(Console.ReadLine());
                double expenses = double.Parse(Console.ReadLine());

                if (i % 3 == 0 && i % 5 != 0)
                {
                    cityProfit = moneyErned - (expenses + expenses * 0.5);
                }

                if (i % 5 == 0)
                {
                    cityProfit = (moneyErned - moneyErned * 0.1) - expenses;

                }

                if (i >= 0 && i % 3 != 0 && i % 5 != 0)
                {
                    cityProfit = moneyErned - expenses;
                }


                totalProfit += cityProfit;

                Console.WriteLine($"In {nameOfCity} Burger Bus earned {cityProfit:f2} leva.");
            }


            Console.WriteLine($"Burger Bus total profit: {totalProfit:f2} leva.");
        }
    }
}