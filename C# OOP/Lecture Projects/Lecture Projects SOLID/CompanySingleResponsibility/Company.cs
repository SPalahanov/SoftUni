using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySingleResponsibility.Models;
using CompanySingleResponsibility.Services;

namespace CompanySingleResponsibility
{
    public class Company
    {
        private List<Employee> employees;
        
        private EmployeeDataService employeeDataService;
        private EmployeeReportsService employeeReportsService;
        private SalaryService salaryService;

        public Company()
        {
            employees = new List<Employee>();
            employeeDataService = new EmployeeDataService();
            employeeReportsService = new EmployeeReportsService();
            salaryService = new SalaryService();
        }
        
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void NewYearUpdate()
        {
            employeeDataService.AddTenure(employees);
            salaryService.PayBonus(employees, 300);
            employeeReportsService.PrintReport(employees);
        }

        public void Report()
        {
            employeeReportsService.PrintReport(employees);
        }
    }
}
