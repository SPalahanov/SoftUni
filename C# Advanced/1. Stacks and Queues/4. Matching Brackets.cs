namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Stack<int> openingBracket = new Stack<int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    openingBracket.Push(i);
                }

                if (text[i] == ')')
                {
                    int openingBracketIndex = openingBracket.Pop();

                    Console.WriteLine(text.Substring(openingBracketIndex, i - openingBracketIndex + 1));
                }
            }
        }
    }
}