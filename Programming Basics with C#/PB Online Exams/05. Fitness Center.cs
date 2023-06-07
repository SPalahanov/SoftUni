using System;

namespace P05.FitnessCenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int visitors = int.Parse(Console.ReadLine());

            int backTrainingCount = 0;
            int chestTrainingCount = 0;
            int legsTrainingCount = 0;
            int absTrainingCount = 0;
            int proteinShakesSold = 0;
            int proteinBarSold = 0;

            //string type = "";
            for (int i = 1; i <= visitors; i++)
            {
                string activity = Console.ReadLine();
                if (activity == "Back")
                {
                    backTrainingCount++;
                }
                else if (activity == "Chest")
                {
                    chestTrainingCount++;
                }
                else if (activity == "Legs")
                {
                    legsTrainingCount++;
                }
                else if (activity == "Abs")
                {
                    absTrainingCount++;
                }
                else if (activity == "Protein shake")
                {
                    proteinShakesSold++;
                }
                else if (activity == "Protein bar")
                {
                    proteinBarSold++;
                }
            }

            int totalPeopleWorkingOut = (backTrainingCount + chestTrainingCount + legsTrainingCount + absTrainingCount);
            int proteinPeopleCount = visitors - totalPeopleWorkingOut;
            double workingOutPeoplePrecentage = ((double)totalPeopleWorkingOut / visitors) * 100;
            double proteinPeoplePrecentage = ((double)proteinPeopleCount / visitors) * 100;

            Console.WriteLine($"{backTrainingCount} - back");
            Console.WriteLine($"{chestTrainingCount} - chest");
            Console.WriteLine($"{legsTrainingCount} - legs");
            Console.WriteLine($"{absTrainingCount} - abs");
            Console.WriteLine($"{proteinShakesSold} - protein shake");
            Console.WriteLine($"{proteinBarSold} - protein bar");
            Console.WriteLine($"{workingOutPeoplePrecentage:f2}% - work out");
            Console.WriteLine($"{proteinPeoplePrecentage:f2}% - protein");

        }
    }
}
