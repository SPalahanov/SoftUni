using System;
using System.Runtime.Intrinsics.X86;

namespace P09.FruitOrVegetable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string duma = Console.ReadLine();

            if (duma == "banana" || duma == "apple" || duma == "kiwi" || duma == "cherry" || duma == "lemon" || duma == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (duma == "tomato" || duma == "cucumber" || duma == "pepper" || duma == "carrot")
            {
                Console.WriteLine("vegetable");

            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
