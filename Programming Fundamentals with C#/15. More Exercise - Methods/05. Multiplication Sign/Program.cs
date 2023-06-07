namespace _05._Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            if (IfProductIsPositive(num1, num2, num3))
            {
                Console.WriteLine("positive");
            }

            if (IfProductIsNegative(num1, num2, num3))
            {
                Console.WriteLine("negative");
            }

            if (IfProductIsZero(num1, num2, num3))
            {
                Console.WriteLine("zero");
            }
        }

        static bool IfProductIsPositive(int num1, int num2, int num3)
        {
            return (num1 > 0 && num2 > 0 && num3 > 0 || num1 < 0 && num2 < 0 && num3 > 0 || num1 < 0 && num2 > 0 && num3 < 0 || num1 > 0 && num2 < 0 && num3 < 0);
        }
        static bool IfProductIsNegative(int num1, int num2, int num3)
        {
            return (num1 < 0 && num2 < 0 && num3 < 0 || num1 < 0 && num2 > 0 && num3 > 0 || num1 > 0 && num2 < 0 && num3 > 0 || num1 > 0 && num2 > 0 && num3 < 0);
        }
        static bool IfProductIsZero(int num1, int num2, int num3)
        {
            return (num1 == 0 || num2 == 0 || num3 == 0);
        }
    }
}