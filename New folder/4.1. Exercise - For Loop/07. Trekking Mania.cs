using System;

namespace P07.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            double allPeople = 0;
            double musala = 0;
            double monblan = 0;
            double kilimandjaro = 0;
            double k2 = 0;
            double everest = 0;

            for (int i = 0; i < groups; i++)
            {
                int peopleInGroup = int.Parse(Console.ReadLine());
                allPeople = allPeople + peopleInGroup;
                if (peopleInGroup >= 0 && peopleInGroup <= 5)
                {
                    musala += peopleInGroup;
                }
                else if (peopleInGroup >= 6 && peopleInGroup <= 12)
                {
                    monblan += peopleInGroup;
                }
                else if (peopleInGroup >= 13 && peopleInGroup <= 25)
                {
                    kilimandjaro += peopleInGroup;
                }
                else if (peopleInGroup >= 26 && peopleInGroup <= 40)
                {
                    k2 += peopleInGroup;
                }
                else if (peopleInGroup >= 41)
                {
                    everest += peopleInGroup;
                }
            }
            Console.WriteLine($"{(musala / allPeople * 100):f2}%");
            Console.WriteLine($"{(monblan / allPeople * 100):f2}%");
            Console.WriteLine($"{(kilimandjaro / allPeople * 100):f2}%");
            Console.WriteLine($"{(k2 / allPeople * 100):f2}%");
            Console.WriteLine($"{(everest / allPeople * 100):f2}%");
        }
    }
}
