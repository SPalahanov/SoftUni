namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Квадратна матрица
            int size = int.Parse(Console.ReadLine());

            string[] directions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //валидни посоки 
            char[,] matrix = new char[size, size];

            int currentRow = 0; //ред на стартиране+
            int currentCol = 0; //колона на стартиране

            int countCoal = 0;

            //прочитане на матрица от конзолата
            for (int row = 0; row < size; row++)
            {
                char[] symbols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = symbols[col];

                    if (symbols[col] == 's')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    else if (symbols[col] == 'c')
                    {
                        countCoal++;
                    }
                }
            }

            foreach (string direction in directions)
            {
                if (direction == "left")
                {
                    //при движение наляво -> колона - 1
                    //валидираме мястото, на което ще отиде преди преместване
                    if (currentCol - 1 >= 0 && currentCol - 1 <= size - 1)
                    {
                        //Преместване
                        currentCol--;

                        //Проверка къде сме отишли
                        char currentElement = matrix[currentRow, currentCol];

                        if (currentElement == 'e')
                        {
                            //Прекратим цикъла с посоките
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return;
                        }
                        else if (currentElement == 'c')
                        {
                            //взимаме полезно изкопаемо
                            matrix[currentRow, currentCol] = '*';

                            countCoal--; //взели едно изкопаемо от матрицата

                            if (countCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                return;
                            }
                        }
                    }
                }
                if (direction == "right")
                {
                    //при движение надясно -> колона + 1
                    if (currentCol + 1 >= 0 && currentCol + 1 <= size - 1)
                    {
                        currentCol++;

                        //Проверка къде сме отишли
                        char currentElement = matrix[currentRow, currentCol];

                        if (currentElement == 'e')
                        {
                            //Прекратим цикъла с посоките
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return;
                        }
                        if (currentElement == 'c')
                        {
                            //взимаме полезно изкопаемо
                            matrix[currentRow, currentCol] = '*';

                            countCoal--; //взели едно изкопаемо от матрицата

                            if (countCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                return;
                            }
                        }
                    }
                }
                if (direction == "up")
                {
                    //при движение нагоре -> ред - 1
                    if (currentRow - 1 >= 0 && currentRow - 1 <= size - 1)
                    {
                        currentRow--;

                        //Проверка къде сме отишли
                        char currentElement = matrix[currentRow, currentCol];

                        if (currentElement == 'e')
                        {
                            //Прекратим цикъла с посоките
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return;
                        }

                        if (currentElement == 'c')
                        {
                            //взимаме полезно изкопаемо
                            matrix[currentRow, currentCol] = '*';

                            countCoal--; //взели едно изкопаемо от матрицата

                            if (countCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                return;
                            }
                        }
                    }
                }
                if (direction == "down")
                {
                    //при движение надолу -> ред + 1
                    
                    if (currentRow + 1 >= 0 && currentRow + 1 <= size - 1)
                    {
                        currentRow++;

                        //Проверка къде сме отишли
                        char currentElement = matrix[currentRow, currentCol];

                        if (currentElement == 'e')
                        {
                            //Прекратим цикъла с посоките
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return;
                        }
                        else if (currentElement == 'c')
                        {
                            //взимаме полезно изкопаемо
                            matrix[currentRow, currentCol] = '*';

                            countCoal--; //взели едно изкопаемо от матрицата

                            if (countCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                return;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"{countCoal} coals left. ({currentRow}, {currentCol})");
        }
    }
}