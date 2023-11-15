using System;
using System.Collections.Generic;
using System.Text;

namespace DetailPrinter.Models
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" with documents: " + string.Join(" ", Documents);
        }
    }
}
