using System;
using System.Threading.Tasks;

namespace P02.ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lowGrade = int.Parse(Console.ReadLine());
            string task;
            double sum = 0;
            int lowGradeCounter = 0;
            int problem = 0;
            string lastProblem = string.Empty;
            while ((task = Console.ReadLine()) != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());
                sum += grade;
                problem++;
                lastProblem = task;
                if (grade <= 4)
                {
                    lowGradeCounter++;
                    if (lowGradeCounter == lowGrade)
                    {
                        Console.WriteLine($"You need a break, {lowGradeCounter} poor grades.");
                        break;
                    }
                }
            }
            if (task == "Enough")
            {
                Console.WriteLine($"Average score: {(sum / problem):f2}");
                Console.WriteLine($"Number of problems: {problem}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
