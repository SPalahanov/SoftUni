using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfNumbers = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= countOfNumbers; i++)
            {
                int sumOfDigits = 0;
                int digits = i;
                while (digits != 0)
                {
                    sumOfDigits += digits % 10;
                    digits = digits / 10;
                }

                bool isSpecial = sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11;

                Console.WriteLine($"{i} -> {isSpecial}");

            }
        }
    }
}