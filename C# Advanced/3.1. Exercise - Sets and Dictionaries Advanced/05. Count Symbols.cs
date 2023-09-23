namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] word = Console.ReadLine()
                .ToArray();

            SortedDictionary<char, int> charsCounts = new SortedDictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                if (!charsCounts.ContainsKey(word[i]))
                {
                    charsCounts.Add(word[i], 0);
                }

                charsCounts[word[i]]++;
            }

            foreach (var charsCount in charsCounts)
            {
                Console.WriteLine($"{charsCount.Key}: {charsCount.Value} time/s");
            }
        }
    }
}