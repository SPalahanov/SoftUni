using SoftUni.Data;
using SoftUni.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SoftUni
{
    public class StartUp
    {
        static void Main()
        {
            var context = new SoftUniContext();
            // 03.
            //Console.WriteLine(GetEmployeesFullInformation(context));

            // 04.
            // Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            // 05.
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            // 06.
            //Console.WriteLine(AddNewAddressToEmployee(context));

            // 07.
            //Console.WriteLine(GetEmployeesInPeriod(context));

            // 08.
            //Console.WriteLine(GetAddressesByTown(context));

            // 09.
            //Console.WriteLine(GetEmployee147(context));

            // 10.
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

            // 11.
            //Console.WriteLine(GetLatestProjects(context));

            // 12.
            //Console.WriteLine(IncreaseSalaries(context));

            // 13.
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));

            // 14.
            //Console.WriteLine(DeleteProjectById(context));

            // 15.
            Console.WriteLine(RemoveTown(context));

        }

        // 03.
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            // Option 1
            //return string.Join(Environment.NewLine, context.Employees
            //   .Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}")
            //   .ToList());

            // Option 2 
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 04.
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var richEmployees = context.Employees
                .Where(e => e.Salary > 50_000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in richEmployees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 05.
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department,
                    e.Salary
                })
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 06.
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };


            var nakov = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            if (nakov != null)
            {
                nakov.Address = newAddress;

                context.SaveChanges();
            }

            var employees = context.Employees
                .OrderByDescending(e => e.Address.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            return string.Join(Environment.NewLine, employees);
        }

        // 07.
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var result = context.Employees
                .Take(10)
                .Select(e => new
                {
                    EmployeeNames = $"{e.FirstName} {e.LastName}",
                    ManagerNames = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e.EmployeesProjects
                        .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            ep.Project.StartDate,
                            ep.Project.EndDate
                        })
                });

            StringBuilder sb = new StringBuilder();

            foreach(var e in result)
            {
                sb.AppendLine($"{e.EmployeeNames} - Manager: {e.ManagerNames}");

                if (e.Projects.Any())
                {
                    foreach (var p in e.Projects)
                    {
                        if (p.EndDate == null)
                        {
                            sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - not finished");
                        } 
                        else
                        {
                            sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                        }
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 08.
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var address = context.Addresses
                .Select(a => new
                {
                    AddressTexts = a.AddressText,
                    TownNames = a.Town.Name,
                    Employees = a.Employees.Count()
                })
                .OrderByDescending(a => a.Employees)
                .ThenBy(a => a.TownNames)
                .ThenBy(a => a.AddressTexts)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var a in address)
            {
                sb.AppendLine($"{a.AddressTexts}, {a.TownNames} - {a.Employees} employees");
            }

            return sb.ToString().TrimEnd();
        }

        // 09.
        public static string GetEmployee147(SoftUniContext context)
        {
            var result = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    EmployeeNames = $"{e.FirstName} {e.LastName} - {e.JobTitle}",
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name
                        })
                        .OrderBy(ep => ep.ProjectName)
                        .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in result)
            {
                sb.AppendLine($"{e.EmployeeNames}");

                if (e.Projects.Any())
                {
                    foreach (var p in e.Projects)
                    {
                        sb.AppendLine($"{p.ProjectName}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 10.
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var result = context.Departments
                .Where(d => d.Employees.Count() > 5)
                .Select(d => new
                {
                    d.Name,
                    Managers = $"{d.Manager.FirstName} {d.Manager.LastName}",
                    Employees = d.Employees
                        .Select(e => new
                        {
                            EmployeeFirstName = e.FirstName,
                            EmployeeLastName = e.LastName,
                            EmployeeJobTitle = e.JobTitle
                        })
                        .OrderBy(e => e.EmployeeFirstName)
                        .ThenBy(e => e.EmployeeLastName)
                        .ToList()
                })
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var d in result)
            {
                sb.AppendLine($"{d.Name} - {d.Managers}");

                if (d.Employees.Any())
                {
                    foreach (var e in d.Employees)
                    {
                        sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - {e.EmployeeJobTitle}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 11.
        public static string GetLatestProjects(SoftUniContext context)
        {
            var result = context.Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })                
                .OrderBy(p => p.StartDate)
                .ToList()
                .TakeLast(10)
                .OrderBy(d => d.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var p in result)
            {
                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{p.StartDate}");
            }

            return sb.ToString().TrimEnd();
        }

        // 12.
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employeesToIncrease = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            if (employeesToIncrease != null)
            {
                foreach (var e in employeesToIncrease)
                {
                    decimal newSalary = e.Salary * (decimal)1.12;

                    e.Salary = newSalary;
                }

                context.SaveChanges();
            }

            StringBuilder sb = new StringBuilder();

            foreach (var e in employeesToIncrease)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return string.Join(Environment.NewLine, sb);
        }

        // 13.
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        // 14.
        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects
                .Find(2);

            var employeeProjects = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2);

            context.EmployeesProjects.RemoveRange(employeeProjects);

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var projectName in projects)
            {
                sb.AppendLine(projectName);
            }

            return sb.ToString().TrimEnd();
        }

        // 15.
        public static string RemoveTown(SoftUniContext context)
        {
            var townToDelete = context.Towns
                .Where(t => t.Name == "Seattle");

            var addressesToDelete = context.Addresses
                .Where(t => t.Town.Name == "Seattle");

            var employees = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle");

            foreach (var e in employees)
            {
                e.AddressId = null;
            }

            var countOfDeleted = addressesToDelete.Count();

            context.Addresses.RemoveRange(addressesToDelete);

            context.Towns.RemoveRange(townToDelete);

            context.SaveChanges();

            return $"{countOfDeleted} addresses in Seattle were deleted";
        }
    }
}
