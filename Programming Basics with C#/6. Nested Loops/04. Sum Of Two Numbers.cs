using System;
using System.Diagnostics.Tracing;

namespace P04.SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int finishNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int counter = 0;
            bool flag = false;
            for (int i = startNumber; i <= finishNumber; i++)
            {
                for (int n = startNumber; n <= finishNumber; n++)
                {
                    counter++;
                    int result = i + n;
                    if (result == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {n} = {magicNumber})");
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }
        }
    }
}
