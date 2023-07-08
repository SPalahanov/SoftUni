namespace _01._Binary_Digits_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int digit = int.Parse(Console.ReadLine());
            int count = 0;

            while (number > 0)
            {
                int remainder = number % 2;

                if (remainder == digit)
                {
                    count++;
                }

                number /= 2;
            }

            if (digit == 0)
            {
                Console.WriteLine($"We have {count} zeroes");
            }

            if (digit == 1)
            {
                Console.WriteLine($"We have {count} ones");
            }
        }
    }
}