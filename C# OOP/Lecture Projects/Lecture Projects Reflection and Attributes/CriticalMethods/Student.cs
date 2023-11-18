using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriticalMethods
{
    [Critical(5)]
    public class Student
    {
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Score = 2;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Critical]
        public int Score { get; set; }

        [Critical(Severity = 3, Message = "This method is important!")]
        public void Print()
        {

        }
    }
}
