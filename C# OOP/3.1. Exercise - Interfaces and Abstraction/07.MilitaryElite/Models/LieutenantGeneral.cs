using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, IReadOnlyCollection<IPrivate> privates) : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var currentPrivate in Privates)
            {
                sb.AppendLine($"  {currentPrivate.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
