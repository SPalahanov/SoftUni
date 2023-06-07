using System;

namespace P05.Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination;
            double budget;
            while ((destination = Console.ReadLine()) != "End")
            {
                budget = double.Parse(Console.ReadLine());
                while (budget > 0)
                {
                    budget -= double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {destination}!");
            }
        }
    }
}