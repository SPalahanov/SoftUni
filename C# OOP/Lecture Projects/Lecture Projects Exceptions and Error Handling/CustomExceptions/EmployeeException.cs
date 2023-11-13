using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class EmployeeException : Exception
    {
        public EmployeeException(string message) 
            : base(message + " in employee")
        {
            
        }

        public Employee Employee { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
