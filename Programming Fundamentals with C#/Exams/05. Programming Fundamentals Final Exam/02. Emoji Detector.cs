using System.Text;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string numbersPattern = @"\d";

            Regex numbersRegex = new Regex(numbersPattern);

            MatchCollection numbersMaches = numbersRegex.Matches(input);

            int coolThresholdSum = 1;

            foreach (Match numbersMach in numbersMaches)
            {
                coolThresholdSum *= int.Parse(numbersMach.Value);
            }

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");

            string emojiPattern = @"(\*{2}|\:{2})([A-Z]{1}[a-z]{2,})\1";

            Regex emojiRegex = new Regex(emojiPattern);

            MatchCollection emojiMatches = emojiRegex.Matches(input);

            StringBuilder coolEmoji = new StringBuilder();

            int countOfAllEmojis = 0;

            foreach (Match match in emojiMatches)
            {
                int coolness = 0;

                countOfAllEmojis++;

                string text = match.Groups[2].Value;

                for (int i = 0; i < text.Length; i++)
                {
                    coolness += text[1];
                }

                if (coolness > coolThresholdSum)
                {
                    coolEmoji.AppendLine(match.Value);
                }
            }

            Console.WriteLine($"{countOfAllEmojis} emojis found in the text. The cool ones are:");

            Console.WriteLine(coolEmoji.ToString());
        }
    }
}