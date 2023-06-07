using System;
using System.Security.Cryptography.X509Certificates;

namespace _04.Workout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysOfTraning = int.Parse(Console.ReadLine());
            double kilometersDay1 = double.Parse(Console.ReadLine());
            double totalKilometers = 0;
            double allkilometers = 0;

            for (int i = 1; i <= daysOfTraning; i++)
            {
                double k = double.Parse(Console.ReadLine()) / 100;

                totalKilometers = kilometersDay1 + (kilometersDay1 * k) + totalKilometers + (totalKilometers * k);

                allkilometers += totalKilometers + kilometersDay1;

                kilometersDay1 = 0;

            }
            //Console.WriteLine(allkilometers);
            if (allkilometers >= 1000)
            {
                Console.WriteLine($"You've done a great job running {Math.Ceiling(allkilometers - 1000)} more kilometers!");
            }
            else
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(1000 - allkilometers)} more kilometers");
            }
        }
    }
}
