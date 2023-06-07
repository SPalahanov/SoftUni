using System;

namespace _01.Excursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleInGroup = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            int transportCard = int.Parse(Console.ReadLine());
            int museumTicket = int.Parse(Console.ReadLine());

            double nightsSumPerPerson = nights * 20; ;
            double transportSum = transportCard * 1.60;
            double museumSum = museumTicket * 6;

            double sumPerPerson = nightsSumPerPerson + transportSum + museumSum;
            double sumForGroup = sumPerPerson * peopleInGroup;
            double totalSum = sumForGroup + (sumForGroup * 0.25);

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
