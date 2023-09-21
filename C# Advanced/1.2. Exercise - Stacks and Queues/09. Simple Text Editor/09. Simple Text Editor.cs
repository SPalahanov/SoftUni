using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersOfOperation = int.Parse(Console.ReadLine());

            string text = String.Empty;
            
            Stack<string> stacks = new Stack<string>();

            for (int i = 0; i < numbersOfOperation; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                if (input[0] == "1")
                {
                    stacks.Push(text);
                    text += input[1];
                }

                if (input[0] == "2")
                {
                    stacks.Push(text);
                    text = text.Substring(0, text.Length - int.Parse(input[1]));
                }

                if (input[0] == "3")
                {
                    Console.WriteLine(text[int.Parse(input[1]) - 1]);
                }

                if (input[0] == "4")
                {
                    text = stacks.Pop();
                }
            }
        }
    }
}