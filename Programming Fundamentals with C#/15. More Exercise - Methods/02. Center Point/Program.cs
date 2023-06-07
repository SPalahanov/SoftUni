using System.Net.WebSockets;

namespace _02._Center_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintCoordinatesOfTheClosestPoint(x1, y1, x2, y2);

        }

        static void PrintCoordinatesOfTheClosestPoint(double x1, double y1, double x2, double y2)
        {
            if (FirstPointDistanceFromTheCenter(x1, y1) <= SecondPointDistancefromCenter(x2, y2))
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }

        static double FirstPointDistanceFromTheCenter(double x1, double y1)
        {
            double distance = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            return distance;
        }

        static double SecondPointDistancefromCenter(double x2, double y2)
        {
            double distance = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));
            return distance;
        }
    }
}