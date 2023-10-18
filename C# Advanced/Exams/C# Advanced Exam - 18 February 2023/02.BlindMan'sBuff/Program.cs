namespace BlindMan_sBuff;

internal class Program
{
    static void Main(string[] args)
    {
        int[] dimensions = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rows = dimensions[0];
        int cols = dimensions[1];

        char[,] matrix = new char[rows, cols];

        int playerRow = 0;
        int playerCol = 0;

        int movesCount = 0;
        int touchedOpponentsCount = 0;

        for (int row = 0; row < rows; row++)
        {
            char[] newRow = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = newRow[col];

                if (matrix[row, col] == 'B')
                {
                    playerRow = row;
                    playerCol = col;
                    matrix[playerRow, playerCol] = '-';
                }
            }
        }

        string command = string.Empty;

        while ((command = Console.ReadLine()) != "Finish")
        {
            if (command == "left")
            {
                if (playerCol == 0)
                {
                    continue;
                }
                else
                {

                    if (matrix[playerRow, playerCol - 1] == 'O')
                    {
                        continue;
                    }

                    if (matrix[playerRow, playerCol - 1] == '-')
                    {
                        movesCount++;
                    }

                    if (matrix[playerRow, playerCol - 1] == 'P')
                    {
                        matrix[playerRow, playerCol - 1] = '-';


                        touchedOpponentsCount++;
                        movesCount++;
                    }

                    playerCol--;
                }
            }
            else if (command == "right")
            {
                if (playerCol == cols - 1)
                {
                    continue;
                }
                else
                {

                    if (matrix[playerRow, playerCol + 1] == 'O')
                    {
                        continue;
                    }

                    if (matrix[playerRow, playerCol + 1] == '-')
                    {
                        movesCount++;
                    }

                    if (matrix[playerRow, playerCol + 1] == 'P')
                    {
                        matrix[playerRow, playerCol + 1] = '-';


                        touchedOpponentsCount++;
                        movesCount++;
                    }

                    playerCol++;
                }
            }
            else if (command == "up")
            {
                if (playerRow == 0)
                {
                    continue;
                }
                else
                {

                    if (matrix[playerRow - 1, playerCol] == 'O')
                    {
                        continue;
                    }

                    if (matrix[playerRow - 1, playerCol] == '-')
                    {
                        movesCount++;
                    }

                    if (matrix[playerRow - 1, playerCol] == 'P')
                    {
                        matrix[playerRow - 1, playerCol] = '-';

                        touchedOpponentsCount++;
                        movesCount++;
                    }

                    playerRow--;
                }
            }
            else if (command == "down")
            {
                if (playerRow == rows - 1)
                {
                    continue;
                }
                else
                {

                    if (matrix[playerRow + 1, playerCol] == 'O')
                    {
                        continue;
                    }

                    if (matrix[playerRow + 1, playerCol] == '-')
                    {
                        movesCount++;
                    }

                    if (matrix[playerRow + 1, playerCol] == 'P')
                    {
                        matrix[playerRow + 1, playerCol] = '-';
                        movesCount++;
                        touchedOpponentsCount++;
                    }

                    playerRow++;
                }
            }

            if (touchedOpponentsCount == 3)
            {
                break;
            }
        }

        Console.WriteLine("Game over!");
        Console.WriteLine($"Touched opponents: {touchedOpponentsCount} Moves made: {movesCount}");
    }
}