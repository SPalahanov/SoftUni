namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0]; //броят на редовете
            int cols = dimensions[1]; //броят на колоните

            string[,] matrix = new string[rows, cols];

            //прочитане на матрица от конзолата
            for (int row = 0; row < rows; row++)
            {
                string[] words = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = words[col];
                }
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                //валидираме командата
                if (IsValidCommand(input, rows, cols))
                {
                    //валидна команда -> изпулнявам командата
                    string[] splittedCommand = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string element1 = matrix[int.Parse(splittedCommand[1]), int.Parse(splittedCommand[2])];
                    string element2 = matrix[int.Parse(splittedCommand[3]), int.Parse(splittedCommand[4])];

                    matrix[int.Parse(splittedCommand[1]), int.Parse(splittedCommand[2])] = element2;
                    matrix[int.Parse(splittedCommand[3]), int.Parse(splittedCommand[4])] = element1;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static bool IsValidCommand(string input, int rows, int cols)
        {
            string[] commandInfo = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //дали е валидно името на командата
            bool isValidName = commandInfo[0] == "swap";

            //дали е валиден бройят на елементите на командата
            bool isValidCountParts = commandInfo.LongLength == 5;

            bool isValidRowsAndCols = false;

            if (isValidName && isValidCountParts)
            {
                int row1 = int.Parse(commandInfo[1]); //ред на първия елемент
                int col1 = int.Parse(commandInfo[2]); //колона на първия елемент
                int row2 = int.Parse(commandInfo[3]); //ред на втория елемент
                int col2 = int.Parse(commandInfo[4]); //колона на втория елемент

                isValidRowsAndCols = row1 >= 0 && row1 < rows
                                                    && col1 >= 0 && col1 < cols
                                                    && row2 >= 0 && row2 < rows
                                                    && col2 >= 0 && col2 < cols;
            }

            return isValidRowsAndCols;
        }

        static void PrintMatrix(string[,] matrix)
        {
            //matrix.GetLength(0) -> брой на редовете на матрица
            //matrix.GetLength(1) -> брой на колоните на матрица

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}