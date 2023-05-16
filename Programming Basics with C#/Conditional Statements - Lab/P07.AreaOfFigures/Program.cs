using System;

namespace P07.AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();
            double area = 0;

            if (figureType == "square")
            {
                double side = double.Parse(Console.ReadLine());
                area = side * side;
            }
            else if (figureType == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = a * b;
            }
            else if (figureType == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                area = Math.PI * radius * radius;
            }
            else if (figureType == "triangle")
            {
                double c = double.Parse(Console.ReadLine());
                double hc = double.Parse(Console.ReadLine());
                area = (c * hc) / 2;
            }
            Console.WriteLine($"{area:f3}");
        }
    }
}
