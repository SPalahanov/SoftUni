using System;

namespace P05.SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int packOfPens = int.Parse(Console.ReadLine());
            int packOfMarker = int.Parse(Console.ReadLine());
            int litersDetergent = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine())/100;

            double pricePens = 5.80 * packOfPens;
            double priceMarker = 7.20 * packOfMarker;
            double priceDetergent = 1.20 * litersDetergent;
            double sum = pricePens + priceMarker + priceDetergent;
            double totalSum = sum - (sum * discount);
            Console.WriteLine(totalSum);
        }
    }
}
