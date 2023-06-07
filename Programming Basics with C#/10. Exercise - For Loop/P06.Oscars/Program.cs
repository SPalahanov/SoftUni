using System;

namespace P06.Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string judgeName = Console.ReadLine();
                double judgePoints = double.Parse(Console.ReadLine());
                int namePoints = 0;
                for (int letter = 1; letter <= judgeName.Length; letter++)
                {
                    namePoints++;
                }
                points = points + ((judgePoints * namePoints) / 2);
                if (points >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {points:f1}!");
                    break;
                }
            }
            if (points < 1250.5)
            {
                Console.WriteLine($"Sorry, {name} you need {Math.Abs(1250.5 - points):f1} more!");
            }
        }
    }
}
