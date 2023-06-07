using System;
using System.Text.RegularExpressions;

namespace _06._Middle_Characters
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            IfStringLengthIsEven(text);

            IfStringLengthIsOdd(text);

        }

        static void IfStringLengthIsEven(string? text)
        {
            if (text.Length % 2 == 0)
            {
                string middleNumbers = text.Substring((text.Length - 2) / 2, 2);

                char[] arr = middleNumbers.ToCharArray();

                PrintMiddleNumberOrNumbers(arr);
            }
        }

        static void IfStringLengthIsOdd(string text)
        {
            if (text.Length % 2 != 0)
            {
                string middleNumbers = text.Substring((text.Length / 2), 1);

                char[] arr = middleNumbers.ToCharArray();

                PrintMiddleNumberOrNumbers(arr);
            }
        }

        static void PrintMiddleNumberOrNumbers(char[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
        }
    }
}