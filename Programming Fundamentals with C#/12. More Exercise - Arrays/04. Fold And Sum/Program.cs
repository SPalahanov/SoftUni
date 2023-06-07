using Microsoft.VisualBasic;

namespace _04._Fold_And_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();




            int[] middleNumbers = new int[numbers.Length / 2];

            for (int i = 0; i < numbers.Length / 2; i++)
            {
                middleNumbers[i] = numbers[i + (numbers.Length / 4)];
            }




            int[] leftNumbers = new int[numbers.Length / 4];

            for (int i = 0; i < numbers.Length / 4; i++)
            {
                leftNumbers[i] = numbers[i];
            }




            Array.Reverse(numbers);

            int[] rightNumbers = new int[numbers.Length / 4];

            for (int i = 0; i < numbers.Length / 4; i++)
            {
                rightNumbers[i] = numbers[i];
            }



            
            Array.Reverse(leftNumbers);

            int[] sideArr = leftNumbers.Concat(rightNumbers).ToArray();




            int[] sum = new int[numbers.Length / 2];

            for (int i = 0; i < sideArr.Length; i++)
            {
                sum[i] = sideArr[i] + middleNumbers[i];
            }

            Console.WriteLine(String.Join(' ', sum));
        }
    }
}