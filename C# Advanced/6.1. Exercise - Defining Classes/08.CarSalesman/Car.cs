using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    internal class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($" {Engine}");
            if (Weight != default)
            {
                sb.AppendLine($" Weight: {Weight}");
            }
            else
            {
                sb.AppendLine($" Weight: n/a");
            }

            if (Color != default)
            {
                sb.AppendLine($" Color: {Color}");
            }
            else
            {
                sb.AppendLine($" Color: n/a");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
