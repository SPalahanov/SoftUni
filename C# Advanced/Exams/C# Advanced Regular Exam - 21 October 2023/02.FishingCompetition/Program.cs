namespace FishingCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int rows = size;
            int cols = size;

            char[,] matrix = new char[rows, cols];

            int shipRow = 0;
            int shipCol = 0;

            int fishCought = 0;

            for (int row = 0; row < rows; row++)
            {
                string newRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = newRow[col];

                    if (matrix[row, col] == 'S')
                    {
                        shipRow = row;
                        shipCol = col;

                        matrix[row, col] = '-';
                    }
                }
            }

            bool isSink = false;

            string command;

            while ((command = Console.ReadLine()) != "collect the nets")
            {
                if (command == "left")
                {
                    if (shipCol == 0)
                    {
                        shipCol = cols - 1;

                        if (char.IsDigit(matrix[shipRow, shipCol]))
                        {
                            fishCought += int.Parse(matrix[shipRow, shipCol].ToString());

                            matrix[shipRow, shipCol] = '-';

                        }
                        else if (matrix[shipRow, shipCol] == 'W')
                        {
                            fishCought = 0;

                            isSink = true;

                            matrix[shipRow, shipCol] = 'S';

                            shipCol--;

                            break;
                        }
                    }
                    else
                    {
                        if (char.IsDigit(matrix[shipRow, shipCol - 1]))
                        {
                            fishCought += int.Parse(matrix[shipRow, shipCol - 1].ToString());

                            matrix[shipRow, shipCol - 1] = '-';

                        }
                        else if (matrix[shipRow, shipCol - 1] == 'W')
                        {
                            fishCought = 0;

                            isSink = true;

                            matrix[shipRow, shipCol - 1] = 'S';

                            shipCol--;

                            break;
                        }

                        shipCol--;
                    }
                }

                if (command == "right")
                {
                    if (shipCol == cols - 1)
                    {
                        shipCol = 0;

                        if (char.IsDigit(matrix[shipRow, shipCol]))
                        {
                            fishCought += int.Parse(matrix[shipRow, shipCol].ToString());

                            matrix[shipRow, shipCol] = '-';

                        }
                        else if (matrix[shipRow, shipCol] == 'W')
                        {
                            fishCought = 0;

                            isSink = true;

                            matrix[shipRow, shipCol] = 'S';

                            shipCol++;

                            break;
                        }
                    }
                    else
                    {
                        if (char.IsDigit(matrix[shipRow, shipCol + 1]))
                        {
                            fishCought += int.Parse(matrix[shipRow, shipCol + 1].ToString());

                            matrix[shipRow, shipCol + 1] = '-';
                        }
                        else if (matrix[shipRow, shipCol + 1] == 'W')
                        {
                            fishCought = 0;

                            isSink = true;

                            matrix[shipRow, shipCol + 1] = 'S';

                            shipCol++;

                            break;
                        }

                        shipCol++;
                    }

                }

                if (command == "up")
                {
                    if (shipRow == 0)
                    {
                        shipRow = rows - 1;

                        if (char.IsDigit(matrix[shipRow, shipCol]))
                        {
                            fishCought += int.Parse(matrix[shipRow, shipCol].ToString());

                            matrix[shipRow, shipCol] = '-';

                        }
                        else if (matrix[shipRow, shipCol] == 'W')
                        {
                            fishCought = 0;

                            isSink = true;

                            matrix[shipRow, shipCol] = 'S';

                            shipRow--;

                            break;
                        }
                    }
                    else
                    {
                        if (char.IsDigit(matrix[shipRow - 1, shipCol]))
                        {
                            fishCought += int.Parse(matrix[shipRow - 1, shipCol].ToString());

                            matrix[shipRow - 1, shipCol] = '-';


                        }
                        else if (matrix[shipRow - 1, shipCol] == 'W')
                        {
                            fishCought = 0;

                            isSink = true;

                            matrix[shipRow - 1, shipCol] = 'S';

                            shipRow--;

                            break;
                        }

                        shipRow--;
                    }
                }

                if (command == "down")
                {
                    if (shipRow == rows - 1)
                    {
                        shipRow = 0;

                        if (char.IsDigit(matrix[shipRow, shipCol]))
                        {
                            fishCought += int.Parse(matrix[shipRow, shipCol].ToString());

                            matrix[shipRow, shipCol] = '-';

                        }
                        else if (matrix[shipRow, shipCol] == 'W')
                        {
                            fishCought = 0;

                            isSink = true;

                            matrix[shipRow, shipCol] = 'S';

                            shipRow++;

                            break;
                        }
                    }
                    else
                    {
                        if (char.IsDigit(matrix[shipRow + 1, shipCol]))
                        {
                            fishCought += int.Parse(matrix[shipRow + 1, shipCol].ToString());

                            matrix[shipRow + 1, shipCol] = '-';


                        }
                        else if (matrix[shipRow + 1, shipCol] == 'W')
                        {
                            fishCought = 0;

                            isSink = true;

                            matrix[shipRow + 1, shipCol] = 'S';

                            shipRow++;

                            break;
                        }

                        shipRow++;
                    }
                }
            }

            matrix[shipRow, shipCol] = 'S';

            if (isSink)
            {
                Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{shipRow},{shipCol}]");
            }
            else
            {
                if (fishCought >= 20)
                {
                    Console.WriteLine("Success! You managed to reach the quota!");
                }
                else
                {
                    Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - fishCought} tons of fish more.");
                }

                if (fishCought > 0)
                {
                    Console.WriteLine($"Amount of fish caught: {fishCought} tons.");
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
}