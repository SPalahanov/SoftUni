﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySingleResponsibility.Models;

namespace CompanySingleResponsibility.Services
{
    public class SalaryService
    {
        public void PayBonus(List<Employee> employees, decimal amount)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name} has {amount} bonus");
            }
        }
    }
}
