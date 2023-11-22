using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Test
{
    public class EmployeeTests
    {
        private Guid guid = Guid.Parse("9b8e53f1-9771-4828-a6e8-145fb741bdd6");
        private string name = "Dimitrichko";
        private decimal salary = 5000m;
        
        [Test]
        public void When_CreatingANewEmployee_Id_ShouldNotBeNull()
        {
            Employee employee = new Employee();

            Assert.AreNotEqual(Guid.Empty, employee.Id);
        }

        [Test]
        public void When_CreatingANewEmployee_Data_ShouldBeSetCorrectly()
        {
            Employee employee = new Employee(guid, name, salary);

            Assert.AreEqual(guid, employee.Id);
            Assert.AreEqual(name, employee.Name);
            Assert.AreEqual(salary, employee.Salary);
        }

        [Test]
        public void When_PrintingAnEmployee_Format_ShouldBeCorrect()
        {
            Employee employee = new Employee(guid, name, salary);

            Assert.AreEqual("9b8e53f1-9771-4828-a6e8-145fb741bdd6 - Dimitrichko is paid - 5000", employee.ToString());
        }
    }
}
