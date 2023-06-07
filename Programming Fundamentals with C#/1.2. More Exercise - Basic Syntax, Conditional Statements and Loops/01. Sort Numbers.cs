using System.ComponentModel.DataAnnotations;

namespace _01.SortNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            if (number1 > number2 && number1 > number3)
            {
                Console.WriteLine(number1);
                
                if (number2 > number3) 
                {
                    Console.WriteLine(number2);
                    Console.WriteLine(number3);
                }
                else
                {
                    Console.WriteLine(number3);
                    Console.WriteLine(number2);
                }
            }
            else if (number2 > number1 && number2 > number3)
            {
                Console.WriteLine(number2);

                if (number1 > number3)
                {
                    Console.WriteLine(number1);
                    Console.WriteLine(number3);
                }
                else
                {
                    Console.WriteLine(number3);
                    Console.WriteLine(number1);
                }
            }
            else if (number3 > number1 && number3 > number2)
            {
                Console.WriteLine(number3);

                if (number1 > number2)
                {
                    Console.WriteLine(number1);
                    Console.WriteLine(number2);
                }
                else
                {
                    Console.WriteLine(number2);
                    Console.WriteLine(number1);
                }
            }
        }
    }
}