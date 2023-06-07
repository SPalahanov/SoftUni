using System;

namespace P01.OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            string input;
            int counter = 0;
            while ((input = Console.ReadLine()) != book)
            {
                if (input == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    break;
                }
                counter++;
            }
            if (input != "No More Books")
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
        }
    }
}
