using System.Diagnostics.Tracing;

namespace _03._Calculations
{
    internal class Program
    {
        
        //• On the first line – a string – "add", "multiply", "subtract", "divide".
        //• On the second line – a number.
        //• On the third line – another number.


        static void Main(string[] args)
        {
            string operation = Console.ReadLine();

            double number = double.Parse(Console.ReadLine());

            double anotherNumber = double.Parse(Console.ReadLine());


            AddResult(operation, number, anotherNumber);
            MultiplyResult(operation, number, anotherNumber);
            SubtractResult(operation, number, anotherNumber);
            DivideResult(operation, number, anotherNumber);
        }

        static void AddResult(string operation, double number, double anotherNumber)
        {
            if (operation == "add")
            {
                double result = number + anotherNumber;
                Console.WriteLine(result);
            }
        }

        static void MultiplyResult(string operation, double number, double anotherNumber)
        {
            if (operation == "multiply")
            {
                double result = number * anotherNumber;
                Console.WriteLine(result);
            }
        }

        static void SubtractResult(string operation, double number, double anotherNumber)
        {
            if (operation == "subtract")
            {
                double result = number - anotherNumber;
                Console.WriteLine(result);
            }
        }

        static void DivideResult(string operation, double number, double anotherNumber)
        {
            if (operation == "divide")
            {
                double result = number / anotherNumber;
                Console.WriteLine(result);
            }
        }
    }
}