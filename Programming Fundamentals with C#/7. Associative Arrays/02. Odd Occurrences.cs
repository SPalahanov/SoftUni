using System.Collections;
using System.Collections.Generic;

namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split()
                .Select(x => x.ToLower())
                .ToArray();

            Dictionary<string, int> counts = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (counts.ContainsKey(words[i]))
                {

                    counts[words[i]]++;
                }
                else
                {
                    counts[words[i]] = 1;
                }
            }

            foreach (var kvp in counts)
            {
                if (kvp.Value % 2 == 0)
                {
                    continue;
                }

                Console.Write(kvp.Key + " ");
            }
        }

    }
}