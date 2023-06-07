using System;

namespace _11._Math_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = Input(out var operators, out var secondNumber);


            Console.WriteLine(Result(operators, firstNumber, secondNumber));
        }

        private static int Input(out string? operators, out int secondNumber)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            operators = Console.ReadLine();
            secondNumber = int.Parse(Console.ReadLine());
            return firstNumber;
        }

        private static double Result(string? operators, int firstNumber, int secondNumber)
        {
            double result = 0;

            if (operators == "*")
            {
                result = firstNumber * secondNumber;
            }
            if (operators == "+")
            {
                result = firstNumber + secondNumber;
            }
            if (operators == "-")
            {
                result = firstNumber - secondNumber;
            }
            
            if (operators == "/")
            {
                result = firstNumber / secondNumber;
            }

            return result;
        }
    }
}