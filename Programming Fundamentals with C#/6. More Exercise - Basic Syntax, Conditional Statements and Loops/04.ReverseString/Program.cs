namespace _04.ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string newText = "";

            for (int i = text.Length - 1; i >= 0; i--)
            {
                newText += text[i];
            }

            Console.WriteLine(newText);
        }
    }
}