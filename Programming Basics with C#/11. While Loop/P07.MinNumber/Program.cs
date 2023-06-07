using System;

namespace P07.MinNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int minNumber = int.MaxValue;
            while ((input = (Console.ReadLine())) != "Stop")
            {
                int number = int.Parse(input);
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }
            Console.WriteLine(minNumber);
        }
    }
}
