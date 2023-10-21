using System;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int rows = size;
            int cols = size;

            char[,] matrix = new char[rows, cols];

            int vankoRow = 0;
            int vankoCol = 0;

            int countOfHoles = 1;
            int countOfRods = 0;

            for (int row = 0; row < rows; row++)
            {
                string newRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = newRow[col];

                    if (matrix[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;

                        matrix[row, col] = '*';
                    }
                }
            }

            bool isElectrocuted = false;

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "left")
                {
                    if (vankoCol == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (matrix[vankoRow, vankoCol - 1] == 'R')
                        {
                            countOfRods++;

                            Console.WriteLine("Vanko hit a rod!");
                            continue;
                        }
                        else if (matrix[vankoRow, vankoCol - 1] == 'C')
                        {
                            matrix[vankoRow, vankoCol - 1] = 'E';

                            isElectrocuted = true;

                            countOfHoles++;

                            break;
                        }
                        else if (matrix[vankoRow, vankoCol - 1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol - 1}]!");
                        }
                        else if (matrix[vankoRow, vankoCol - 1] == '-')
                        {
                            matrix[vankoRow, vankoCol - 1] = '*';

                            countOfHoles++;
                        }

                        vankoCol--;
                    }
                }

                if (command == "right")
                {
                    if (vankoCol == cols - 1)
                    {
                        continue;
                    }
                    else
                    {
                        if (matrix[vankoRow, vankoCol + 1] == 'R')
                        {
                            countOfRods++;

                            Console.WriteLine("Vanko hit a rod!");
                            continue;
                        }
                        else if (matrix[vankoRow, vankoCol + 1] == 'C')
                        {
                            matrix[vankoRow, vankoCol + 1] = 'E';

                            isElectrocuted = true;

                            countOfHoles++;

                            break;
                        }
                        else if (matrix[vankoRow, vankoCol + 1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol + 1}]!");
                        }
                        else if (matrix[vankoRow, vankoCol + 1] == '-')
                        {
                            matrix[vankoRow, vankoCol + 1] = '*';

                            countOfHoles++;
                        }

                        vankoCol++;
                    }
                }

                if (command == "up")
                {
                    if (vankoRow == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (matrix[vankoRow - 1, vankoCol] == 'R')
                        {
                            countOfRods++;

                            Console.WriteLine("Vanko hit a rod!");
                            continue;
                        }
                        else if (matrix[vankoRow - 1, vankoCol] == 'C')
                        {
                            matrix[vankoRow - 1, vankoCol] = 'E';

                            isElectrocuted = true;

                            countOfHoles++;

                            break;
                        }
                        else if (matrix[vankoRow - 1, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow - 1}, {vankoCol}]!");
                        }
                        else if (matrix[vankoRow - 1, vankoCol] == '-')
                        {
                            matrix[vankoRow - 1, vankoCol] = '*';

                            countOfHoles++;
                        }

                        vankoRow--;
                    }
                }

                if (command == "down")
                {
                    if (vankoRow == rows - 1)
                    {
                        continue;
                    }
                    else
                    {
                        if (matrix[vankoRow + 1, vankoCol] == 'R')
                        {
                            countOfRods++;

                            Console.WriteLine("Vanko hit a rod!");
                            continue;
                        }
                        else if (matrix[vankoRow + 1, vankoCol] == 'C')
                        {
                            matrix[vankoRow + 1, vankoCol] = 'E';

                            isElectrocuted = true;

                            countOfHoles++;

                            break;
                        }
                        else if (matrix[vankoRow + 1, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow + 1}, {vankoCol}]!");
                        }
                        else if (matrix[vankoRow + 1, vankoCol] == '-')
                        {
                            matrix[vankoRow + 1, vankoCol] = '*';

                            countOfHoles++;
                        }

                        vankoRow++;
                    }
                }
            }

            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");

                matrix[vankoRow, vankoCol] = 'V';
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Join("", matrix[row, col]));
                }

                Console.WriteLine();
            }
        }
    }
}
