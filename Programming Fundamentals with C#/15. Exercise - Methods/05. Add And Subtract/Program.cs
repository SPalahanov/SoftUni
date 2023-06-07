using System.Runtime.ExceptionServices;

namespace _05._Add_And_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var first = InputThreeIntegers(out var second, out var third);


            Console.WriteLine(SubtractsTheThirdIntegerFromTheSumOfTheFirstTwo(first, second, third));
        }

        private static int InputThreeIntegers(out int second, out int third)
        {
            int first = int.Parse(Console.ReadLine());
            second = int.Parse(Console.ReadLine());
            third = int.Parse(Console.ReadLine());
            return first;
        }

        static int ReturnsTheSumOfTheFirstTwoIntegers(int first, int second)
        {
            int sum = 0;

            sum = first + second;

            return sum;
        }

        static int SubtractsTheThirdIntegerFromTheSumOfTheFirstTwo(int first, int second, int third)
        {
            int sub = 0;

            sub = ReturnsTheSumOfTheFirstTwoIntegers(first, second) - third;

            return sub;
        }
    }
}