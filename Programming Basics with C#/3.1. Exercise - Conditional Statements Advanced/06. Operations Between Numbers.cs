using System;

namespace P06.OperationsBetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            if (operation == '+' || operation == '*' || operation == '-')
            {
                int result = 0;
               
                if (operation == '+')
                {
                    result = num1 + num2;
                }
                else if (operation == '-')
                {
                    result = num1 - num2;
                }
                else if (operation == '*')
                {
                    result = num1 * num2;
                }

                string evenOrOdd = "odd";

                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }

                Console.WriteLine($"{num1} {operation} {num2} = {result} - {evenOrOdd}");
            }
            else if (operation == '/' || operation == '%')
            {
                double result = 0;
                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else if (operation == '/')
                {
                    Console.WriteLine($"{num1} / {num2} = {(double)num1 / num2:f2}");
                }
                else if (operation == '%')
                {
                    result = num1 % num2;
                    Console.WriteLine($"{num1} {operation} {num2} = {result}");
                }
                
            }

        }
    }
}
