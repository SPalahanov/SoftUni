namespace _02.FromLeftToTheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= n; i++)
            {

                string input = Console.ReadLine(); 
                string[] splitted = input.Split(" ");

                long number1 = Convert.ToInt64(splitted[0]);
                long number2 = Convert.ToInt64(splitted[1]);

                long digit1;
                long digit2;

                long sumOfDigit1 = 0;
                long sumOfDigit2 = 0;

                if (number1 >= number2)
                {
                    while (Math.Abs(number1) > 0)
                    {
                        long result1 = number1 / 10;
                        digit1 = number1 % 10;
                        sumOfDigit1 += digit1;
                        number1 = result1;
                    }

                    Console.WriteLine(Math.Abs(sumOfDigit1));
                }
                else
                {
                    while (Math.Abs(number2) > 0)
                    {
                        long result2 = number2 / 10;
                        digit2 = number2 % 10;
                        sumOfDigit2 += digit2;
                        number2 = result2;
                    }

                    Console.WriteLine(Math.Abs(sumOfDigit2));
                }
            }
        }
    }
}