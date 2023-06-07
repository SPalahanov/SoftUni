using System;

namespace P07.Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            string input;
            int freeSpace = width * height * lenght;
            while (freeSpace > 0)
            {
                input = Console.ReadLine();
                if (input == "Done")
                {
                    break;
                }
                freeSpace -= int.Parse(input);
            }
            if (freeSpace < 0)
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
            }
            else
            {
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }
        }
    }
}
