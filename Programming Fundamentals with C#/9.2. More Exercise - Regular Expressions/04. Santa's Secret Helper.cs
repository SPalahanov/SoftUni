using System.Text;
using System.Text.RegularExpressions;

namespace _04._Santa_s_Secret_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string input;

            List<string> goodChildren = new List<string>();

            while ((input = Console.ReadLine()) != "end")
            {
                StringBuilder sb = new StringBuilder();

                foreach (var letter in input)
                {
                    int letterNum = letter;
                    int newLetterNumber = letterNum - key;

                    char newLetter = (char)newLetterNumber;

                    sb.Append(newLetter);
                }

                string pattern = @"@([A-Za-z]+)[^@\-!:>]*!([GN])!";

                Regex regex = new Regex(pattern);

                MatchCollection matches = regex.Matches(sb.ToString());

                foreach (Match match in matches)
                {
                    if (match.Groups[2].Value == "G")
                    {
                        goodChildren.Add(match.Groups[1].Value);
                    }
                }
            }

            foreach (var child in goodChildren)
            {
                Console.WriteLine(child);
            }
        }
    }
}