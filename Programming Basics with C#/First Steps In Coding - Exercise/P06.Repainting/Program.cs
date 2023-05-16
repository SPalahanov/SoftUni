using System;

namespace P06.Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            double paint = double.Parse(Console.ReadLine());
            int thiner = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double nylonPrice = (nylon + 2) * 1.50;
            double paintPrice = (paint + (paint * 10 / 100)) * 14.50;
            double thinerPrice = thiner * 5.00;
            double bagPrice = 0.40;

            double materialsPrice = nylonPrice + paintPrice + thinerPrice + bagPrice;
            double laborPrice = (materialsPrice * 30 / 100) * hours;
            double totalSum = materialsPrice + laborPrice;

            Console.WriteLine(totalSum);
        }
    }
}
