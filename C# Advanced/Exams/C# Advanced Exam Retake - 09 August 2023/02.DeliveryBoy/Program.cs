using System.Data;

namespace _02.DeliveryBoy
{
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

            int boyRow = 0;
            int boyCol = 0;

            int boyStartRow = 0;
            int boyStartCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string newRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = newRow[col];

                    if (matrix[row, col] == 'B')
                    {
                        boyRow = row;
                        boyCol = col;

                        boyStartRow = row;
                        boyStartCol = col;
                    }
                }
            }

            bool isOutSideMatrix = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "left")
                {
                    if (boyCol == 0)
                    {
                        if (matrix[boyRow, boyCol] == '-')
                        {
                            matrix[boyRow, boyCol] = '.';
                        }

                        isOutSideMatrix = true;

                        Console.WriteLine("The delivery is late. Order is canceled.");

                        break;
                    }
                    else
                    {
                        if (matrix[boyRow, boyCol - 1] == '*')
                        {
                            continue;
                        }

                        if (matrix[boyRow, boyCol] != 'R')
                        {
                            matrix[boyRow, boyCol] = '.';
                        }

                        boyCol--;
                    }
                }
                else if (command == "right")
                {
                    if (boyCol == cols - 1)
                    {
                        if (matrix[boyRow, boyCol] == '-')
                        {
                            matrix[boyRow, boyCol] = '.';
                        }

                        isOutSideMatrix = true;

                        Console.WriteLine("The delivery is late. Order is canceled.");

                        break;
                    }
                    else
                    {
                        if (matrix[boyRow, boyCol + 1] == '*')
                        {
                            continue;
                        }

                        if (matrix[boyRow, boyCol] != 'R')
                        {
                            matrix[boyRow, boyCol] = '.';
                        }

                        boyCol++;
                    }
                }
                else if (command == "up")
                {
                    if (boyRow == 0)
                    {
                        if (matrix[boyRow, boyCol] == '-')
                        {
                            matrix[boyRow, boyCol] = '.';
                        }

                        isOutSideMatrix = true;

                        Console.WriteLine("The delivery is late. Order is canceled.");

                        break;
                    }
                    else
                    {
                        if (matrix[boyRow - 1, boyCol] == '*')
                        {
                            continue;
                        }

                        if (matrix[boyRow, boyCol] != 'R')
                        {
                            matrix[boyRow, boyCol] = '.';
                        }

                        boyRow--;
                    }
                }
                else if (command == "down")
                {
                    if (boyRow == rows - 1)
                    {
                        if (matrix[boyRow, boyCol] == '-')
                        {
                            matrix[boyRow, boyCol] = '.';
                        }

                        isOutSideMatrix = true;

                        Console.WriteLine("The delivery is late. Order is canceled.");

                        break;
                    }
                    else
                    {
                        if (matrix[boyRow + 1, boyCol] == '*')
                        {
                            continue;
                        }

                        if (matrix[boyRow, boyCol] != 'R')
                        {
                            matrix[boyRow, boyCol] = '.';
                        }

                        boyRow++;
                    }
                }

                if (matrix[boyRow, boyCol] == 'P')
                {
                    matrix[boyRow, boyCol] = 'R';

                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");

                    continue;
                }

                if (matrix[boyRow, boyCol] == 'A')
                {
                    matrix[boyRow, boyCol] = 'P';

                    Console.WriteLine("Pizza is delivered on time! Next order...");

                    break;
                }
            }

            if (isOutSideMatrix)
            {
                matrix[boyStartRow, boyStartCol] = ' ';
            }
            else
            {
                matrix[boyStartRow, boyStartCol] = 'B';
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Join(" ", matrix[row, col]));
                }

                Console.WriteLine();
            }
        }
    }
}