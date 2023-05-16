using System;

namespace P08.PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kuche = int.Parse(Console.ReadLine());
            int kotka = int.Parse(Console.ReadLine());
            double hranaKuche = kuche * 2.50;
            double hranaKotka = kotka * 4;
            double krainaSuma = hranaKotka + hranaKuche;
            Console.WriteLine($"{krainaSuma} lv.");
        }
    }
}
