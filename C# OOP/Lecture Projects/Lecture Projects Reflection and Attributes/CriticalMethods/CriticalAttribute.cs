using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriticalMethods
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
    public class CriticalAttribute : Attribute
    {
        public CriticalAttribute(int severity)
        {
            Severity = severity;
        }

        public CriticalAttribute()
        {

        }

        public int Severity { get; set; }
        public string Message { get; set; }
    }
}
