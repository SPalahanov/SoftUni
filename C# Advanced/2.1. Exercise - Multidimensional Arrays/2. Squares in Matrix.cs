namespace _2._Squares_in_Matrix
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

            char[,] matrix = new char[rows, cols];

            //Прочитане на матрица от конзолата
            for (int row = 0; row < rows; row++)
            {
                char[] symbols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            //Броят на матриците 2х2
            int count = 0;  //брой на матрици

            for (int row = 0; row < rows - 1; row++) //не включваме елементите от последния ред
            {
                for (int col = 0; col < cols - 1; col++) //не включваме елементите от последната колона
                {
                    int element = matrix[row, col];

                    //дали съвпада с този в дясно -> колона + 1
                    bool isEqualRight = element == matrix[row, col + 1];

                    //дали съвпада с този отдолу -> ред + 1
                    bool isEqualDown = element == matrix[row + 1, col];

                    //дали съвпада с този по диагонал -> ред + 1, колона + 1
                    bool isEqualDiagonal = element == matrix[row + 1, col + 1];

                    if (isEqualRight && isEqualDown && isEqualDiagonal)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}