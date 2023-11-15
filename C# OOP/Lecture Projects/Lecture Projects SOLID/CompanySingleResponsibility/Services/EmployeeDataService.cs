using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySingleResponsibility.Models;

namespace CompanySingleResponsibility.Services
{
    public class EmployeeDataService
    {
        public void AddTenure(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                employee.YearsInCompany++;
            }

        }
    }
}
