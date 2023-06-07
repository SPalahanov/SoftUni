using System;
using System.Diagnostics;
using System.Numerics;

namespace _05.BestPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerName;
            int topPleyerGoals = 0;
            string topPlayer = "";
            
            while ((playerName = Console.ReadLine()) != "END")
            {
                int goals = int.Parse(Console.ReadLine());
               
                if (goals > topPleyerGoals)
                {
                    topPleyerGoals = goals;
                    topPlayer = playerName;
                }
                if (goals >= 10)
                {
                    break;
                }
            }
            Console.WriteLine($"{topPlayer} is the best player!");
            if (topPleyerGoals >= 3)
            {
                Console.WriteLine($"He has scored {topPleyerGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {topPleyerGoals} goals.");
            }
        }
    }
}
