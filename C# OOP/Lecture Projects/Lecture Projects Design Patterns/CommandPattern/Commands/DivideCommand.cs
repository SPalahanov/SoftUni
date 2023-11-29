using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    class DivideCommand : Command
    {
        public DivideCommand(decimal value) : base(value)
        {
            Operator = '*';
        }

        public override decimal Execute(decimal currentValue)
        {
            return currentValue / Value;
        }

        public override decimal UnExecute(decimal currentValue)
        {
            return currentValue * Value;
        }
    }
}
