using System;

namespace P05.AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            double balance = 0;

            while ((input = Console.ReadLine()) != "NoMoreMoney")
            {
                double deposit = double.Parse(input);
                if (deposit < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                balance += deposit;
                Console.WriteLine($"Increase: {deposit:f2}");
            }
            Console.WriteLine($"Total: {balance:f2}");
        }
    }
}
