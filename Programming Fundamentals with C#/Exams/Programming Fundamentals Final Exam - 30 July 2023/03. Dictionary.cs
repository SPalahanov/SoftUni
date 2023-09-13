using System.Text;

namespace _03._Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            string[] wordsAndDefinitions = Console.ReadLine().Split(" | ");

            foreach (string wordDefinition in wordsAndDefinitions)
            {
                string[] tokens = wordDefinition.Split(": ");
                string word = tokens[0];
                string definition = tokens[1];

                if (!dictionary.ContainsKey(word))
                {
                    dictionary[word] = new List<string>();
                }

                dictionary[word].Add(definition);
            }

            string[] givenWords = Console.ReadLine().Split(" | ");

            string command = Console.ReadLine();

            if (command == "Test")
            {
                foreach (var givenWord in givenWords)
                {
                    if (dictionary.ContainsKey(givenWord))
                    {
                        Console.WriteLine($"{givenWord}:");

                        foreach (var kvp in dictionary[givenWord])
                        {
                            Console.WriteLine($" -{kvp}");
                        }
                    }
                }
            }

            if (command == "Hand Over")
            {
                StringBuilder sb = new StringBuilder();
                
                foreach (var kvp in dictionary)
                {
                    sb.Append(kvp.Key);
                    sb.Append(" ");
                }

                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}