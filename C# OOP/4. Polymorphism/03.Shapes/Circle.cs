using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }
        
        public double Radius  { get; private set; }

        public override double CalculatePerimeter()
        {
            return 2 * Radius * Math.PI;
        }

        public override double CalculateArea()
        {
            return (Radius * Radius) * Math.PI;
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(base.Draw() + this.GetType().Name);
            //sb.AppendLine($"Perimeter: {CalculatePerimeter():f2}");
            //sb.AppendLine($"Area: {CalculateArea():f2}");

            return sb.ToString().Trim();
        }
        
    }
}
