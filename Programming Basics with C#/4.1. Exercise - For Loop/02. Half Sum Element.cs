using System;

namespace P02.HalfSumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxNum = int.MinValue;
            int maxSum = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                maxSum = maxSum + num;
                if (num > maxNum)
                {
                    maxNum = num;
                }
            }
            maxSum -= maxNum;
            if (maxSum == maxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxNum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(maxNum - maxSum)}");
            }
        }
    }
}
