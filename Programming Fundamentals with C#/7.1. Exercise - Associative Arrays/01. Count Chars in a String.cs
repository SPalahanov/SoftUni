namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> charOccurrences = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char character = input[i];

                if (character == ' ')
                {
                    continue;
                }

                if (!charOccurrences.ContainsKey(character))
                {
                    charOccurrences.Add(character, 0);
                }

                charOccurrences[character]++;
            }

            foreach (var pair in charOccurrences)
            {
                char character = pair.Key;
                int occurrences = pair.Value;

                Console.WriteLine($"{character} -> {occurrences}");
            }
        }
    }
}