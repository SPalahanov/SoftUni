using System.Threading.Channels;

namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool HasOddNumber(int num)
        {
            int countOddDigits = 0;

            while (num > 0)
            {
                int rem = num % 10;
                
                if (rem % 2 != 0)
                {
                    return true;
                }
                
                num /= 10;
            }

            return false;
        }

        static bool IsDevisibleByEight(int num)
        {
            int sumOfAllDigits = 0;

            while (num > 0)
            {
                int digit = num % 10;
                num /= 10;
                sumOfAllDigits += digit;
            }

            return sumOfAllDigits % 8 == 0;

        }

        static bool IsTopNumber(int num)
        {
            if (IsDevisibleByEight(num) && HasOddNumber(num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}