using System;
 
namespace P02_PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(1);

            if (n == 1)
            {
                return;
            }

            int[] secondRowArray = new int[] { 1, 1 };
            Console.WriteLine(string.Join(" ", secondRowArray));

            if (n == 2)
            {
                return;
            }

            else
            {
                for (int i = 0; i < secondRowArray.Length + 1; i++)
                {
                    int[] pasclArray = new int[secondRowArray.Length + 1];

                    pasclArray[0] = 1;

                    pasclArray[pasclArray.Length - 1] = 1;


                    for (int j = 1; j < pasclArray.Length - 1; j++)
                    {
                        pasclArray[j] = secondRowArray[j - 1] + secondRowArray[j];
                    }

                    Console.WriteLine(string.Join(" ", pasclArray));

                    secondRowArray = pasclArray;

                    if (secondRowArray.Length == n)
                    {
                        break;
                    }
                }
            }
        }
    }
}