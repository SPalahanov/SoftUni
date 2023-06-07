using System;

namespace P06.WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double time1M = double.Parse(Console.ReadLine());

            double delay = Math.Floor(meters / 15) * 12.5;
            double ivanTime = meters * time1M + delay;

            if(ivanTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {ivanTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {Math.Abs(record - ivanTime):f2} seconds slower.");
            }
        }
    }
}
