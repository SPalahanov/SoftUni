using Console = System.Console;

namespace _04._Bit_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int positin = int.Parse(Console.ReadLine());

            int mask = ~(1 << positin);
            int result = number & mask;

            Console.WriteLine(result);
        }
    }
}