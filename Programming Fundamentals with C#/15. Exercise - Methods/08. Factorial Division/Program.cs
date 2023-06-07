namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong first = ulong.Parse(Console.ReadLine());
            ulong second = ulong.Parse(Console.ReadLine());

            Console.WriteLine($"{(FactorialOfFirstNumber(first) / FactorialOfSecondNumber(second)):f2}");
        }

        static double FactorialOfFirstNumber(ulong first)
        {
            ulong fact = 1;
            for (ulong i = 1; i <= first; i++)
            {
                fact *= i;
            }
            return fact;
        }

        static double FactorialOfSecondNumber(ulong second)
        {
            ulong fact = 1;
            for (ulong i = 1; i <= second; i++)
            {
                fact *= i;
            }
            return fact;
        }
    }
}