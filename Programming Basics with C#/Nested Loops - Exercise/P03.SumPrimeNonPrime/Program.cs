using System;

namespace P03.SumPrimeNonPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input;

            int num;
            bool isPrime;

            int primeSum = 0;
            int nonPrimeSum = 0;

            while ((input = Console.ReadLine()) != "stop")
            {
                num = int.Parse(input);
                isPrime = true;

                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    for (int i = 2; i < num; i++)
                    {
                        if (num % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }
                
                if (isPrime && num > 0)
                {
                    primeSum += num;
                }
                else if (num > 0)
                {
                    nonPrimeSum += num; 
                }
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
