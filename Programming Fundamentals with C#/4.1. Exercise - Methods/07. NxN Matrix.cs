using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string result = ReturnMatrixNxN(n);
            Console.WriteLine(result);
        }

        static string ReturnMatrixNxN(int n)
        {
            string result = "";
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    result += $"{n} ";
                }

                result += "\n";
            }

            return result;
        }
    }
}