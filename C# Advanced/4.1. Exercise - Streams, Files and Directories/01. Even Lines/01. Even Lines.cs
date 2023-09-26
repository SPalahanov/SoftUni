using System.Text;

namespace EvenLines
{
    using System;
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = string.Empty;

                int count = 0;
                
                while (line != null)
                {
                    line = reader.ReadLine();

                    if (count++ % 2 == 0)
                    {
                        string replacedSymbols = ReplaceSymbols(line);
                        
                        string reversedWords = ReversedWords(replacedSymbols);

                        sb.AppendLine(reversedWords);
                    }
                }
            }
            
            return sb.ToString().TrimEnd();
        }

        private static string ReplaceSymbols(string? line)
        {
            StringBuilder sb = new StringBuilder(line);

            char[] symbolsToReplace = { '-', ',', '.', '!', '?' };

            foreach (char symbol in symbolsToReplace)
            {
                sb = sb.Replace(symbol, '@');
            }

            return sb.ToString();
        }

        private static string ReversedWords(string replacedSymbols)
        {
            string[] reversedWords = replacedSymbols
                .Split(" ",  StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            return string.Join(" ", reversedWords);
        }
    }
}
