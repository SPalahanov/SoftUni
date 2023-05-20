namespace _05.DecryptingMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfLines = int.Parse(Console.ReadLine());

            string word = "";

            for (int i = 1; i <= numberOfLines; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                int numberInDecimal = (int)symbol;
                char newsymbol = (char)(numberInDecimal + key);
                string letter = newsymbol.ToString();
                word += letter;
            }
            Console.WriteLine(word);
        }
    }
}