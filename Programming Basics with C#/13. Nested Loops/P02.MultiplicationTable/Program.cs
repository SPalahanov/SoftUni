using System;

namespace P02.MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int multiplier1 = 1; multiplier1 <=10; multiplier1++)
            {
                for (int multiplier2 = 1; multiplier2 <=10; multiplier2++)
                {
                    Console.WriteLine($"{multiplier1} * {multiplier2} = {multiplier1 * multiplier2}");
                }
            }
        }
    }
}
