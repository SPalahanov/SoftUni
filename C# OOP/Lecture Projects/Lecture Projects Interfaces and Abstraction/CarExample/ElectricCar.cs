using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExample
{
    public class ElectricCar : IDrivable
    {
        public void Start()
        {
            Console.WriteLine("Start engine");
            
        }

        public void Accelerate()
        {
            ++Speed;

            Console.WriteLine("Put more power in engine");
            Console.WriteLine($"Speed: {++Speed}");
        }

        public void Break()
        {
            --Speed;
            
            Console.WriteLine("Put more power in brakes");
            Console.WriteLine($"Speed: {--Speed}");
        }

        public int Speed { get; set; }
    }
}
