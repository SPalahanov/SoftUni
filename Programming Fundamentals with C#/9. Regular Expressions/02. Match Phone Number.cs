using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern =
                @"([+][3][5][9])(?:\-)([2])(?:\-)(\d{3}(?:\-)\d{4})|([+][3][5][9])(?:\ )([2])(?:\ )(\d{3}(?:\ )\d{4})";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            var machedPhones = matches
                .Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", machedPhones));
        }
    }
}