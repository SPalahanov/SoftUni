using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(@(?<leftWord>[A-Za-z]{3,})@@(?<rightWord>[A-Za-z]{3,})@)|(#(?<leftWord>[A-Za-z]{3,})##(?<rightWord>[A-Za-z]{3,})#)";

            Dictionary<string, string> mirrorWords = new Dictionary<string, string>();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            int mirrorPairCounter = 0;

            foreach (Match match in matches)
            {
                string left = match.Groups["leftWord"].Value;

                string right = match.Groups["rightWord"].Value;

                char[] reversed = right.ToCharArray();

                Array.Reverse(reversed);

                string reversedRight = new string(reversed);

                if (left == reversedRight)
                {
                    mirrorWords.Add(left, right);

                    mirrorPairCounter++;
                }
            }

            if (mirrorPairCounter > 0)
            {
                Console.WriteLine("The mirror words are:");

                Console.WriteLine(string.Join(", ", mirrorWords.Select(mirrorWord => $"{mirrorWord.Key} <=> {mirrorWord.Value}")));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}