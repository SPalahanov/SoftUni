namespace _12.RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfNumbers = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int num = 1; num <= countOfNumbers; num++)
            {
                int digit = num;
                int sumOfDigit = 0;
                while (digit != 0)
                {
                    sumOfDigit += digit % 10;
                    digit = digit / 10;
                }
                bool isSpecialNum = (sumOfDigit == 5) || (sumOfDigit == 7) || (sumOfDigit == 11);

                Console.WriteLine($"{num} -> {isSpecialNum}");
            }

        }
    }
}