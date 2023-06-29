namespace _01._Company_Roster
{
    class Employee
    {
        public Employee(string name, decimal salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            int employeeCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < employeeCount; i++)
            {
                string[] employeeData = Console.ReadLine().Split();

                string name = employeeData[0];
                decimal salary = decimal.Parse(employeeData[1]);
                string department = employeeData[2];

                Employee employee = new Employee(name, salary, department);
                
                employees.Add(employee);

                employees = employees.OrderByDescending(x => x.Salary).ToList();
            }

            var highestAverageSalaryDepartment = employees
                .GroupBy(e => e.Department)
                .OrderByDescending(g => g.Average(e => e.Salary))
                .First();

            Console.WriteLine($"Highest Average Salary: {highestAverageSalaryDepartment.Key:f2}");

            foreach (Employee employee in highestAverageSalaryDepartment)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }
        
    }
}