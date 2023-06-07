using System;
using System.Diagnostics;

namespace P06.EasterCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string topBakerName = "";
            int topBackerPoints = 0;
            for (int i = 1; i <= n; i++)
            {
                string backerName = Console.ReadLine();
                int currentBackerPoints = 0;

                string command;
                while ((command = Console.ReadLine()) != "Stop")
                {
                    int currentPoints = int.Parse(command);
                    currentBackerPoints += currentPoints;
                }

                Console.WriteLine($"{backerName} has {currentBackerPoints} points.");
                if (currentBackerPoints > topBackerPoints)
                {
                    topBackerPoints = currentBackerPoints;
                    topBakerName = backerName;
                    
                    Console.WriteLine($"{topBakerName} is the new number 1!");
                }
            }
            Console.WriteLine($"{topBakerName} won competition with {topBackerPoints} points!");
        }
    }
}
