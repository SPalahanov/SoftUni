using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Models.Contracts;

namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        public FreeDiver(string name)
            : base(name, 120)
        {
        }

        public override void Miss(int TimeToCatch)
        {

            double decreasePercentage = 0.6;

            int oxygenDecrease = (int)Math.Round(TimeToCatch * decreasePercentage, MidpointRounding.AwayFromZero);

            OxygenLevel -= oxygenDecrease;
        }

        public override void RenewOxy()
        {
            OxygenLevel = 120;
        }
    }
}
