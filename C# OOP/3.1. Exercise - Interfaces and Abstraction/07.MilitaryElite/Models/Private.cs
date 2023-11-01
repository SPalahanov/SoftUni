using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }

        //public override string ToString()
        //{
        //    return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary}";
        //}

        public override string ToString()
        {
            return base.ToString() + $" Salary: {Salary:f2}";
        }
    }
}
