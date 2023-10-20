namespace HelpAMole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int rows = size;
            int cols = size;

            char[,] matrix = new char[rows, cols];

            int moleRow = 0;
            int moleCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string newRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = newRow[col];

                    if (matrix[row, col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;

                        matrix[row, col] = '-';
                    }
                }
            }

            int molePoints = 0;

            bool specialLocation = false;

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                if (molePoints >= 25)
                {
                    break;
                }

                if (command == "left")
                {
                    if (moleCol == 0)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                    else if (matrix[moleRow, moleCol - 1] == '-')
                    {
                        moleCol--;
                    }
                    else if (matrix[moleRow, moleCol - 1] == 'S')
                    {
                        matrix[moleRow, moleCol - 1] = '-';

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                if (matrix[row, col] == 'S')
                                {
                                    matrix[row, col] = '-';

                                    moleRow = row;
                                    moleCol = col;

                                    molePoints -= 3;

                                    specialLocation = true;
                                    break;
                                }
                            }

                            if (specialLocation)
                            {
                                break;
                            }
                        }
                    }
                    else if (char.IsDigit(matrix[moleRow, moleCol - 1]))
                    {
                        molePoints += int.Parse(matrix[moleRow, moleCol - 1].ToString());

                        matrix[moleRow, moleCol - 1] = '-';
                        moleCol--;
                    }
                }

                if (command == "right")
                {
                    if (moleCol == cols - 1)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                    else if (matrix[moleRow, moleCol + 1] == '-')
                    {
                        moleCol++;
                    }
                    else if (matrix[moleRow, moleCol + 1] == 'S')
                    {
                        matrix[moleRow, moleCol + 1] = '-';

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                if (matrix[row, col] == 'S')
                                {
                                    matrix[row, col] = '-';

                                    moleRow = row;
                                    moleCol = col;

                                    molePoints -= 3;

                                    specialLocation = true;
                                    break;
                                }
                            }

                            if (specialLocation)
                            {
                                break;
                            }
                        }
                    }
                    else if (char.IsDigit(matrix[moleRow, moleCol + 1]))
                    {
                        molePoints += int.Parse(matrix[moleRow, moleCol + 1].ToString());

                        matrix[moleRow, moleCol + 1] = '-';
                        moleCol++;
                    }
                }

                if (command == "up")
                {
                    if (moleRow == 0)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                    else
                    {
                        if (matrix[moleRow - 1, moleCol] == '-')
                        {
                            moleRow--;
                        }
                        else if (matrix[moleRow - 1, moleCol] == 'S')
                        {
                            matrix[moleRow - 1, moleCol] = '-';

                            for (int row = 0; row < rows; row++)
                            {
                                for (int col = 0; col < cols; col++)
                                {
                                    if (matrix[row, col] == 'S')
                                    {
                                        matrix[row, col] = '-';

                                        moleRow = row;
                                        moleCol = col;

                                        molePoints -= 3;

                                        specialLocation = true;
                                        break;
                                    }
                                }

                                if (specialLocation)
                                {
                                    break;
                                }
                            }
                        }
                        else if (char.IsDigit(matrix[moleRow - 1, moleCol]))
                        {
                            molePoints += int.Parse(matrix[moleRow - 1, moleCol].ToString());

                            matrix[moleRow - 1, moleCol] = '-';
                            moleRow--;
                        }
                    }
                }

                if (command == "down")
                {
                    if (moleRow == rows - 1)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                    else
                    {
                        if (matrix[moleRow + 1, moleCol] == '-')
                        {
                            moleRow++;
                        }
                        else if (matrix[moleRow + 1, moleCol] == 'S')
                        {
                            matrix[moleRow + 1, moleCol] = '-';

                            for (int row = 0; row < rows; row++)
                            {
                                for (int col = 0; col < cols; col++)
                                {
                                    if (matrix[row, col] == 'S')
                                    {
                                        matrix[row, col] = '-';

                                        moleRow = row;
                                        moleCol = col;

                                        molePoints -= 3;

                                        specialLocation = true;
                                        break;
                                    }
                                }

                                if (specialLocation)
                                {
                                    break;
                                }
                            }
                        }
                        else if (char.IsDigit(matrix[moleRow + 1, moleCol]))
                        {
                            molePoints += int.Parse(matrix[moleRow + 1, moleCol].ToString());

                            matrix[moleRow + 1, moleCol] = '-';
                            moleRow++;
                        }
                    }
                }
            }

            matrix[moleRow, moleCol] = 'M';

            if (molePoints >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {molePoints} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {molePoints} points.");
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