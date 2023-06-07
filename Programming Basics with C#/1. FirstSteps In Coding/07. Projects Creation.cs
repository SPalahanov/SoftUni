using System;

namespace P07.ProjectsCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numProj = int.Parse(Console.ReadLine());
            double workHours = 3 * numProj; 

            Console.WriteLine($"The architect {name} will need {workHours} hours to complete {numProj} project/s.");
        }
    }
}
