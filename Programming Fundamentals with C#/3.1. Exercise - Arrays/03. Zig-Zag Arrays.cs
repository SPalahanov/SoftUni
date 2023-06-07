using System.Globalization;

namespace _03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArray = new int [n];
            int[] secondArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i % 2 == 0)
                    {
                        firstArray[i] = numbers[0];
                        secondArray[i] = numbers[1];
                    }
                    else
                    {
                        firstArray[i] = numbers[1];
                        secondArray[i] = numbers[0];
                    }
                }
            }
            Console.WriteLine(string.Join(" ", firstArray));
            Console.WriteLine(string.Join(" ", secondArray));
        }
    }
}