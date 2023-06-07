using System;

namespace P08.TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTournament = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            string typeOfTournament;
            int points = 0;
            double wins = 0;

            

            for (int i = 1; i <= numberOfTournament; i++)
            {
                typeOfTournament = Console.ReadLine();
                if (typeOfTournament == "W")
                {
                    points += 2000;
                    wins++;
                }
                if (typeOfTournament == "F")
                {
                    points += 1200;
                }
                if (typeOfTournament == "SF")
                {
                    points += 720;
                }
            }
            
            Console.WriteLine($"Final points: {startingPoints + points}");
            Console.WriteLine($"Average points: {points / numberOfTournament}");
            Console.WriteLine($"{(wins / numberOfTournament) * 100:f2}%");
        }
    }
}
