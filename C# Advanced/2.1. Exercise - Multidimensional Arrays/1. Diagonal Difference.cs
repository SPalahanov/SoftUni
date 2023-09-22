using System.Data;
using System.Net;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //размер на матрицата: брой редове = брой колони
            int size = int.Parse(Console.ReadLine());

            //[ред, колона]
            int[,] matrix = new int[size, size];

            //Прочитане на матрица от конзолата
            for (int row = 0; row < size; row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            //сума от числата на главния диагонал -> номер на ред = номер на колона
            int primaryDiagonal = 0;

            //сума от числата на второстепенния диагонал -> номер на колона = size - 1 - номер на ред
            int secondaryDiagonal = 0;

            //обхождаме матрицата
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int element = matrix[row, col]; // текущ елемент
                    
                    if (row == col)
                    {
                        //елементът е на главния диагонал
                        primaryDiagonal += element;
                    }

                    if (col == size - 1 - row)
                    {
                        //елементът е на второстепенниа диагонал
                        secondaryDiagonal += element;
                    }
                }
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}