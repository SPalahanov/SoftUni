namespace _06._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRow = int.Parse(Console.ReadLine());

            int[][] jagged = new int[matrixRow][];

            for (int row = 0; row < matrixRow; row++)
            {
                int[] rowValues = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                jagged[row] = rowValues;
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] argument = input
                    .Split(" ")
                    .ToArray();

                int row = int.Parse(argument[1]);
                int col = int.Parse(argument[2]);
                int value = int.Parse(argument[3]);

                if (row >= 0 && row < matrixRow && col >= 0 && col < jagged[row].Length)
                {
                    if (argument[0] == "Add")
                    {
                        jagged[row][col] += value;
                    }

                    if (argument[0] == "Subtract")
                    {
                        jagged[row][col] -= value;

                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write($"{jagged[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}