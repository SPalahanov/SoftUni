namespace _03._Longer_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            CheckFirstOrSecondLineIsLonger(x1, x2, y1, y2, x3, x4, y3, y4);
        }

        private static void CheckFirstOrSecondLineIsLonger(double x1, double x2, double y1, double y2, double x3, double x4, double y3, double y4)
        {
            if (FirstLineLength(x1, x2, y1, y2) >= SecondLineLength(x3, x4, y3, y4))
            {
                PrintFirstLineClosestPointCoordinates(x1, y1, x2, y2);
            }
            else
            {
                PrintSecondLineClosestPointCoordinates(x3, y3, x4, y4);
            }
        }


        static void PrintSecondLineClosestPointCoordinates(double x3, double y3, double x4, double y4)
        {
            if (FirstPointFromSecondLineDistance(x3, y3) <= SecondPointFromSecondLineDistance(x4, y4))
            {
                Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
            }
            else
            {
                Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
            }
        }
        static double FirstPointFromSecondLineDistance(double x3, double y3)
        {
            double distance = Math.Sqrt(Math.Pow(x3, 2) + Math.Pow(y3, 2));
            return distance;
        }
        static double SecondPointFromSecondLineDistance(double x4, double y4)
        {
            double distance = Math.Sqrt(Math.Pow(x4, 2) + Math.Pow(y4, 2));
            return distance;
        }


        static void PrintFirstLineClosestPointCoordinates(double x1, double y1, double x2, double y2)
        {
            if (FirstPointFromFirstLineDistance(x1, y1) <= SecondPointFromFirstLineDistance(x2, y2))
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
        }
        static double FirstPointFromFirstLineDistance(double x1, double y1)
        {
            double distance = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            return distance;
        }
        static double SecondPointFromFirstLineDistance(double x2, double y2)
        {
            double distance = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));
            return distance;
        }


        static double FirstLineLength(double x1, double x2, double y1, double y2)
        {
            double length = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return length;
        }
        static double SecondLineLength(double x3, double x4, double y3, double y4)
        {
            double length = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));
            return length;
        }
    }
}