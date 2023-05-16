using System;
using System.Diagnostics.Tracing;

namespace P04.TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int judge = int.Parse(Console.ReadLine());
            string project;
            double totalGrade = 0;
            int counter = 0;

            
            while ((project = Console.ReadLine()) != "Finish")
            {
                counter++;
                double sum = 0;
                for (int i = 1; i <= judge; i++)
                {
                     double grade = double.Parse(Console.ReadLine());
                    sum += grade;
                }
                Console.WriteLine($"{project} - {(sum / judge):f2}.");
                totalGrade += sum;
                
            }
            if (project == "Finish")
            {
                Console.WriteLine($"Student's final assessment is {(totalGrade / (counter * judge)):f2}.");
            }
        }
    }
}
