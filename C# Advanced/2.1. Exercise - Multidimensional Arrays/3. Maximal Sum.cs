namespace _3._Maximal_Sum
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

            int[,] matrix = new int[rows, cols];

            //Прочитане на матрица от конзолата
            for (int row = 0; row < rows; row++)
            {
                int[] number = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = number[col];
                }
            }

            int maxSum = int.MinValue;
            int[][] maxSumMatrix = new int[3][];

            for (int row = 0; row < rows - 2; row++) //не включваме елементите от последните два реда
            {
                for (int col = 0; col < cols - 2; col++) //не включваме елементите от последните две колони
                {
                    int element = matrix[row, col];

                    int currentSum = 0;
                    int[][] currentMatrix = new int[3][];

                    for (int k = 0; k < 3; k++)
                    {
                        currentMatrix[k] = new int[3];
                        for (int l = 0; l < 3; l++)
                        {
                            currentMatrix[k][l] = matrix[row + k, col + l];
                            currentSum += currentMatrix[k][l];
                        }
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSumMatrix = currentMatrix;
                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(string.Join(" ", maxSumMatrix[i]));
            }
        }
    }
}