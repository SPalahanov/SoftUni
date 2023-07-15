using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(\b(?<![^\s])\b(?![\._\-])[A-Za-z0-9]+[\.\-_]*[A-Za-z0-9]+)@[^\.\-](?:[A-Za-z\.\-]+\.)+[A-Za-z]+";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}