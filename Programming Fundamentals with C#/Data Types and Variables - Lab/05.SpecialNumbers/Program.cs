using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= number; i++)
            {
                int sumOfDigits = 0;
                int digits = i;
                while (digits > 0)
                {
                    sumOfDigits += digits % 10;
                    digits = digits / 10;
                }

                if (i / 5 == 0 || i / 7 == 0 || i / 11 == 0)
                {
                    Console.WriteLine($"{sumOfDigits} ->True");
                }
                else
                {
                    Console.WriteLine($"{sumOfDigits} ->False");
                }


                //sum = sumOfDigits / 5;
                //if (sum == 0)
                //{
                //    Console.WriteLine($"{sumOfDigits} ->True");
                //}
                //else
                //{
                //    Console.WriteLine($"{sumOfDigits} ->False");
                //}
            }
        }
    }
}