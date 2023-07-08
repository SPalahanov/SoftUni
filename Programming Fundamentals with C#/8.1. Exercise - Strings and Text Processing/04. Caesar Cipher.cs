using System.Text;

namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                int charToNumber = Convert.ToInt32(input[i]);

                int result = charToNumber + 3;

                char symbol = (char)result;

                sb.Insert(0, symbol.ToString());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}