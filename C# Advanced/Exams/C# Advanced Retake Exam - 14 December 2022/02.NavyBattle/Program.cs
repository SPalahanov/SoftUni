namespace _02.NavyBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());

            int rows = dimension;
            int cols = dimension;

            int submarineRow = 0;
            int submarineCol = 0;

            int hitMineCount = 0;
            int destroyedCruiseCount = 0;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string newRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = newRow[col];

                    if (matrix[row, col] == 'S')
                    {
                        matrix[row, col] = '-';
                        submarineRow = row;
                        submarineCol = col;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "left")
                {
                    submarineCol--;
                    
                    if (matrix[submarineRow, submarineCol] == '-')
                    {
                        continue;
                    }
                    
                    if (matrix[submarineRow, submarineCol] == '*')
                    {
                        hitMineCount++;

                        if (hitMineCount == 3)
                        {
                            matrix[submarineRow, submarineCol] = 'S';

                            break;
                        }

                        matrix[submarineRow, submarineCol] = '-';
                    }
                    else if (matrix[submarineRow, submarineCol] == 'C')
                    {
                        destroyedCruiseCount++;

                        if (destroyedCruiseCount == 3)
                        {
                            matrix[submarineRow, submarineCol] = 'S';

                            break;
                        }

                        matrix[submarineRow, submarineCol] = '-';
                    }
                }
                else if (command == "right")
                {
                    submarineCol++;

                    if (matrix[submarineRow, submarineCol] == '-')
                    {
                        continue;
                    }

                    if (matrix[submarineRow, submarineCol] == '*')
                    {
                        hitMineCount++;

                        if (hitMineCount == 3)
                        {
                            matrix[submarineRow, submarineCol] = 'S';

                            break;
                        }

                        matrix[submarineRow, submarineCol] = '-';
                    }
                    else if (matrix[submarineRow, submarineCol] == 'C')
                    {
                        destroyedCruiseCount++;

                        if (destroyedCruiseCount == 3)
                        {
                            matrix[submarineRow, submarineCol] = 'S';

                            break;
                        }

                        matrix[submarineRow, submarineCol] = '-';
                    }
                }
                else if (command == "up")
                {
                    submarineRow--;

                    if (matrix[submarineRow, submarineCol] == '-')
                    {
                        continue;
                    }

                    if (matrix[submarineRow, submarineCol] == '*')
                    {
                        hitMineCount++;

                        if (hitMineCount == 3)
                        {
                            matrix[submarineRow, submarineCol] = 'S';

                            break;
                        }

                        matrix[submarineRow, submarineCol] = '-';
                    }
                    else if (matrix[submarineRow, submarineCol] == 'C')
                    {
                        destroyedCruiseCount++;

                        if (destroyedCruiseCount == 3)
                        {
                            matrix[submarineRow, submarineCol] = 'S';

                            break;
                        }

                        matrix[submarineRow, submarineCol] = '-';
                    }
                }
                else if (command == "down")
                {
                    submarineRow++;

                    if (matrix[submarineRow, submarineCol] == '-')
                    {
                        continue;
                    }

                    if (matrix[submarineRow, submarineCol] == '*')
                    {
                        hitMineCount++;

                        if (hitMineCount == 3)
                        {
                            matrix[submarineRow, submarineCol] = 'S';

                            break;
                        }

                        matrix[submarineRow, submarineCol] = '-';
                    }
                    else if (matrix[submarineRow, submarineCol] == 'C')
                    {
                        destroyedCruiseCount++;

                        if (destroyedCruiseCount == 3)
                        {
                            matrix[submarineRow, submarineCol] = 'S';

                            break;
                        }

                        matrix[submarineRow, submarineCol] = '-';
                    }
                }
            }

            if (hitMineCount == 3)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
            }
            else
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
            
        }
    }
}