using System.Numerics;
using System.Threading.Channels;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }

            int countRemoved = 0;

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] symbols = Console.ReadLine().ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            while (true)
            {
                int maxAttack = 0;
                int rowMaxAttack = 0;
                int colMaxAttack = 0;
                
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        char currentElement = matrix[row, col];

                        if (currentElement == 'K')
                        {
                            int countAttackedKnights = CalculateAttackedKnight(row, col, size, matrix);

                            if (countAttackedKnights > maxAttack)
                            {
                                maxAttack = countAttackedKnights;
                                rowMaxAttack = row;
                                colMaxAttack = col;
                            }
                        }
                    }
                }

                if (maxAttack == 0)
                {
                     break;
                }
                else
                {
                    matrix[rowMaxAttack, colMaxAttack] = '0';
                    countRemoved++;
                }
            }

            Console.WriteLine(countRemoved);
        }

        static int CalculateAttackedKnight(int row, int col, int size, char[,] matrix)
        {
            int count = 0;
            //2 нагоре 1 надясно -> ред - 2, колона + 1
            //1 надясно 2 нагоре -> ред - 2, колона + 1
            if (IsValidate(row - 2, col + 1, size))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    count++;
                }
            }

            //2 нагоре 1 наляво -> ред - 2, колона - 1
            //1 наляво 2 нагоре -> ред - 2, колона - 1
            if (IsValidate(row - 2, col - 1, size))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    count++;
                }
            }

            //2 надолу 1 надясно -> ред + 2, колона + 1
            //1 надясно 2 надолу -> ред + 2, колона + 1
            if (IsValidate(row + 2, col + 1, size))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    count++;
                }
            }

            //2 надолу 1 наляво -> ред + 2, колона - 1
            //1 наляво 2 надолу -> ред + 2, колона - 1
            if (IsValidate(row + 2, col - 1, size))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    count++;
                }
            }

            //2 наляво 1 нагоре -> ред - 1, колона - 2
            //1 нагоре 2 наляво -> ред - 1, колона - 2
            if (IsValidate(row - 1, col - 2, size))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    count++;
                }
            }

            //2 наляво 1 надолу -> ред + 1, колона - 2
            //1 надолу 2 наляво -> ред + 1, колона - 2
            if (IsValidate(row + 1, col - 2, size))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    count++;
                }
            }

            //2 надясно 1 нагоре -> ред - 1, колона + 2
            //1 нагоре 2 надясно -> ред - 1, колона + 2
            if (IsValidate(row - 1, col + 2, size))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    count++;
                }
            }

            //2 надясно 1 надолу -> ред + 1, колона + 2
            //1 надолу 2 надясно -> ред + 1, колона + 2
            if (IsValidate(row + 1, col + 2, size))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    count++;
                }
            }

            return count;
        }

        static bool IsValidate(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}