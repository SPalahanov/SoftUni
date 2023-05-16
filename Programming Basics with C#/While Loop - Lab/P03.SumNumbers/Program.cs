using System;

namespace P03.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialSum = int.Parse(Console.ReadLine());

            int numberSum = 0;
            while (numberSum < initialSum)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                numberSum += currentNumber;
            }
            Console.WriteLine(numberSum);
        }
    }
}
