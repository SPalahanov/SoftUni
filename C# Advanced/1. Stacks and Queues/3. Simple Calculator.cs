using static System.Net.Mime.MediaTypeNames;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split().ToArray();

            Stack<string> tokens = new Stack<string>();

            for (int i = expression.Length - 1; i >= 0; i--)
            {
                tokens.Push(expression[i]);
            }

            int sum = int.Parse(tokens.Pop());

            while (tokens.Count > 0)
            {
                string operation = tokens.Pop();
                
                if (operation == "+")
                {
                    sum += int.Parse(tokens.Pop());
                }

                if (operation == "-")
                {
                    sum -= int.Parse(tokens.Pop());
                }
            }

            Console.WriteLine(sum);
        }
    }
}