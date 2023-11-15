using System;
using System.Collections.Generic;
using DetailPrinter.Models;

namespace DetailPrinter
{
    class Program
    {
        static void Main()
        {
            DetailsPrinter printer = new DetailsPrinter(new List<Employee>()
            {
                new Employee("Pesho"),
                new Manager("Gosho", new List<string>() {"Document1", "Document2", "Document3"})

            });

            printer.PrintDetails();
        }
    }
}
