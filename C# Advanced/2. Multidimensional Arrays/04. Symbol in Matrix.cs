namespace _04._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int rows = size;
            int cols = size;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string rowValues = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = Convert.ToChar(rowValues[col]);
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            bool found = false;
            int matchedSymbolRow = - 1;
            int matchedSymbolCol = - 1;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        found = true;
                        matchedSymbolRow = row;
                        matchedSymbolCol = col;
                    }
                }

                if (found)
                {
                    break;
                }
            }

            if (found)
            {
                Console.WriteLine($"({matchedSymbolRow}, {matchedSymbolCol})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}