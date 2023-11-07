using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    { 
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        
        public double Height  { get; private set; }
        public double Width { get; private set; }
        public override double CalculatePerimeter()
        {
            return 2 * Height + 2 * Width;
        }

        public override double CalculateArea()
        {
            return Height * Width;
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
