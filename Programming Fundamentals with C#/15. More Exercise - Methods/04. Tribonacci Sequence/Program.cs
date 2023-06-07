using System.Numerics;

namespace _04._Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            ulong[] tribonacciArray = new ulong[n];
            
            IfNumberIsOne(n, tribonacciArray);

            IfNumberIsTwo(n, tribonacciArray);

            IfNumberIsThree(n, tribonacciArray);

            IfNumberIsBiggerThanThree(n, tribonacciArray);

            PrintNumbersFromTheTribonacciSequence(tribonacciArray);
            }
        
        static void IfNumberIsOne(int n, ulong[] tribonacciArray)
        {
            if (n <= 1)
            {
                tribonacciArray[0] = 1;
            }
        }
        
        static void IfNumberIsTwo(int n, ulong[] tribonacciArray)
        {
            if (n == 2)
            {
                tribonacciArray[0] = 1;
                tribonacciArray[1] = 1;
            }
        }

        static void IfNumberIsThree(int n, ulong[] tribonacciArray)
        {
            if (n == 3)
            {
                tribonacciArray[0] = 1;
                tribonacciArray[1] = 1;
                tribonacciArray[2] = 2;
            }
        }

        static void IfNumberIsBiggerThanThree(int n, ulong[] tribonacciArray)
        {
            if (n > 3)
            {
                tribonacciArray[0] = 1;
                tribonacciArray[1] = 1;
                tribonacciArray[2] = 2;
                for (int i = 3; i < n; i++)
                {
                    ulong currentNum = tribonacciArray[i - 1] + tribonacciArray[i - 2] + tribonacciArray[i - 3];
                    tribonacciArray[i] = currentNum;
                }
            }
        }
        static void PrintNumbersFromTheTribonacciSequence(ulong[] tribonacciArray)
        {
            Console.WriteLine(string.Join(' ', (tribonacciArray)));
        }
    }
}