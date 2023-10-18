namespace TheSquirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int rows = size;
            int cols = size;

            int squirrelRow = 0;
            int squirrelCol = 0;

            char[,] matrix = new char[rows, cols];

            string[] commands = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<string> commandsList = new List<string>();

            foreach (string command in commands)
            {
                commandsList.Add(command);
            }

            for (int row = 0; row < rows; row++)
            {
                string newRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = newRow[col];

                    if (matrix[row, col] == 's')
                    {
                        squirrelRow = row;
                        squirrelCol = col;

                        matrix[row, col] = '*';
                    }
                }
            }

            int collectedHazelnuts = 0;

            bool isOutOfMatrix = false;
            bool isSquirrelStepOnTrap = false;

            foreach (var comand in commandsList)
            {
                if (comand == "left")
                {
                    if (squirrelCol == 0)
                    {
                        isOutOfMatrix = true;
                    }
                    else
                    {
                        squirrelCol--;

                        if (matrix[squirrelRow, squirrelCol] == 't')
                        {
                            isSquirrelStepOnTrap = true;
                            break;
                        }

                        if (matrix[squirrelRow, squirrelCol] == '*')
                        {
                            continue;
                        }

                        if (matrix[squirrelRow, squirrelCol] == 'h')
                        {
                            collectedHazelnuts++;
                            matrix[squirrelRow, squirrelCol] = '*';
                        }
                    }
                }
                else if (comand == "right")
                {
                    if (squirrelCol == cols - 1)
                    {
                        isOutOfMatrix = true;
                    }
                    else
                    {
                        squirrelCol++;

                        if (matrix[squirrelRow, squirrelCol] == 't')
                        {
                            isSquirrelStepOnTrap = true;
                            break;
                        }

                        if (matrix[squirrelRow, squirrelCol] == '*')
                        {
                            continue;
                        }

                        if (matrix[squirrelRow, squirrelCol] == 'h')
                        {
                            collectedHazelnuts++;
                            matrix[squirrelRow, squirrelCol] = '*';
                        }
                    }
                }
                else if (comand == "up")
                {
                    if (squirrelRow == 0)
                    {
                        isOutOfMatrix = true;
                    }
                    else
                    {
                        squirrelRow--;

                        if (matrix[squirrelRow, squirrelCol] == 't')
                        {
                            isSquirrelStepOnTrap = true;
                            break;
                        }

                        if (matrix[squirrelRow, squirrelCol] == '*')
                        {
                            continue;
                        }

                        if (matrix[squirrelRow, squirrelCol] == 'h')
                        {
                            collectedHazelnuts++;
                            matrix[squirrelRow, squirrelCol] = '*';
                        }
                    }
                }
                else if (comand == "down")
                {
                    if (squirrelRow == rows - 1)
                    {
                        isOutOfMatrix = true;
                        break;
                    }
                    else
                    {
                        squirrelRow++;

                        if (matrix[squirrelRow, squirrelCol] == 't')
                        {
                            isSquirrelStepOnTrap = true;
                            break;
                        }

                        if (matrix[squirrelRow, squirrelCol] == '*')
                        {
                            continue;
                        }

                        if (matrix[squirrelRow, squirrelCol] == 'h')
                        {
                            collectedHazelnuts++;
                            matrix[squirrelRow, squirrelCol] = '*';
                        }
                    }
                }
            }

            if (isOutOfMatrix)
            {
                Console.WriteLine("The squirrel is out of the field.");
            }

            if (isSquirrelStepOnTrap)
            {
                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            }

            if (collectedHazelnuts == 3)
            {
                matrix[squirrelRow, squirrelCol] = 's';

                Console.WriteLine("Good job! You have collected all hazelnuts!");
            }

            if (isOutOfMatrix == false && isSquirrelStepOnTrap == false && collectedHazelnuts < 3)
            {
                Console.WriteLine("There are more hazelnuts to collect.");
            }

            Console.WriteLine($"Hazelnuts collected: {collectedHazelnuts}");
        }
    }
}