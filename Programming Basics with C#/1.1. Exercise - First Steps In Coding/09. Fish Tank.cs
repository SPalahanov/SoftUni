using System;

namespace P09.FishTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int weight = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            double aquariumVolum = lenght * weight * height;
            double volumLiters = aquariumVolum * 0.001;
            double occupiedSpace = percentage / 100;
            double litersNeeded = volumLiters * (1 - occupiedSpace);

            Console.WriteLine(litersNeeded);
        }
    }
}
