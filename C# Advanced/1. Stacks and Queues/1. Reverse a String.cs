namespace _1._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Stack<string> stacks = new Stack<string>();

            for (int i = 0; i < text.Length; i++)
            {
                stacks.Push(text[i].ToString());
            }

            while (stacks.Count > 0)
            {
                Console.Write(stacks.Pop());
            }
        }
    }
}