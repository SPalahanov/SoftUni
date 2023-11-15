using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySingleResponsibility.Models
{
    public class Employee
    {
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public int YearsInCompany { get; set; }
    }
}
