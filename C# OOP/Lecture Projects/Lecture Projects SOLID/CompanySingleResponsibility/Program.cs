using CompanySingleResponsibility.Models;

namespace CompanySingleResponsibility
{
    public class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "new year")
                {
                    company.NewYearUpdate();
                }
                if (command == "new employee")
                {
                    company.AddEmployee(new Employee() {Name = "Slavi"});
                }
                if (command == "report")
                {
                    company.Report();
                }
            }
        }
    }
}