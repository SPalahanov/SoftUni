using System;

namespace P06.Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            int allPiece = lenght * width;
            string input;

            while (allPiece > 0)
            {
                input = Console.ReadLine();

                if (input == "STOP")
                {
                    break;
                }
                allPiece -= int.Parse(input);
            }
            if (allPiece < 0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(allPiece)} pieces more.");
            }
            else
            {
                Console.WriteLine($"{allPiece} pieces are left.");
            }
        }
    }
}
