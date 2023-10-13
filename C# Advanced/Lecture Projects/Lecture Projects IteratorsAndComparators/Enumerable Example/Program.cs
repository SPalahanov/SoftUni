using System.Runtime.CompilerServices;

namespace Enumerable_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new(2,4);
            Point point2 = new(5, 3);

            Console.WriteLine(point.X.CompareTo(point2.X));
            List<Point> points = new();

            points.Add(point);
            points.Add(point2);
            points.Add(new Point(3,8));
            points.Add(new Point(5,1));

            points.Sort();

            foreach (var item in points)
            {
                Console.WriteLine($"Point with coordinates ({item.X} : {item.Y})");
            }
        }
    }

    class Point : IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int CompareTo(Point otherPoint)
        {
            if (this.X != otherPoint.X)
            {
                return (this.X - otherPoint.X);
            }

            if (this.Y != otherPoint.Y)
            {
                return (this.Y - otherPoint.Y);
            }

            return 0;
        }
    }
}