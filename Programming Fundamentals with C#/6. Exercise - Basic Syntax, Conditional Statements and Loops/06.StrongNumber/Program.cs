namespace _06.StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int startNumber = number;
            int sumOfFactorial;
            int remainder = 0;
            int totalSum = 0;

            while (number != 0)
            {
                remainder = number % 10;
                number /= 10;
                sumOfFactorial = 1;

                for (int i = 1; i <= remainder; i++)
                {
                    sumOfFactorial *= i;
                }

                totalSum += sumOfFactorial;
            }
            //Console.WriteLine(sum); - Sum of factorials

            if (totalSum == startNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}