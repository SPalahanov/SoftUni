
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExample
{
    public class DieselCar : IDrivable
    {
        public void Start()
        {
            Console.WriteLine("Start engine");
            Console.WriteLine("Doing complex stuff with engine -> 200 lines of code");
        }

        public void Accelerate()
        {
            Console.WriteLine("Put more power in engine");
            Console.WriteLine($"Speed: {++Speed}");
        }

        public void Break()
        {
            Console.WriteLine("Put more power in brakes");
            Console.WriteLine($"Speed: {--Speed}");
        }

        public int Speed { get; set; }
    }
}
