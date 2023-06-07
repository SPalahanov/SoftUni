using System;
using System.Data;

namespace P01.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            double income = r * c;

            if (type == "Premiere")
            {
                Console.WriteLine($"{(income * 12.00):f2}");
            }
            else if (type == "Normal")
            {
                Console.WriteLine($"{(income * 7.50):f2}");
            }
            else
            {
                Console.WriteLine($"{(income * 5.00):f2}");
            }
        }
    }
}
