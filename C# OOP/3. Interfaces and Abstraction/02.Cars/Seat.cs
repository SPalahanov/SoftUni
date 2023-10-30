using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string name, string color)
        {
            this.Color = color;
            this.Model = Model;

            Console.WriteLine(Start());
            Stop();
        }
        
        public string Model { get; set; }
        public string Color { get; set; }
        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak";
        }

        public override string ToString()
        {
            return $"{this.Color} Seat {this.Model}";
        }
    }
}
