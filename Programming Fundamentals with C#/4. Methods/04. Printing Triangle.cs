namespace _04._Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintTriangle(n);
        }

        static void PrintTriangle(int n)
        {
            PrintTopPart(n);
            PrintBottomPart(n - 1);
        }

        static void PrintTopPart(int n)
        {
            for (int row = 1; row <= n; row++)
            {
                PrintTriangleRow(row);
            }
        }

        static void PrintBottomPart(int n)
        {
            for (int row = n; row >= 1; row--)
            {
                PrintTriangleRow(row);
            }
        }

        static void PrintTriangleRow(int row)
        {
            for (int col = 1; col <= row; col++)
            {
                Console.Write(col + " ");
            }

            Console.WriteLine();
        }
    }
}