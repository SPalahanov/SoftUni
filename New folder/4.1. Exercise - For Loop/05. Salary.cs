using System;

namespace P05.Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            string internetPage;
            
            for (int i = 1; i <= tabs; i++)
            {
                internetPage = Console.ReadLine();
                if (internetPage == "Facebook" )
                {
                    salary -= 150;
                }
                else if (internetPage == "Instagram")
                {
                    salary -= 100;
                }
                else if (internetPage == "Reddit")
                {
                    salary -= 50;
                }

                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }
            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
        }
    }
}
