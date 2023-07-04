using System.Runtime.InteropServices;

namespace _04._Word_Filte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split()
                .ToArray();
            
           Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (var word in words)
            {
                if (word.Length % 2 == 0)
                {
                    Console.Write(word);
                    Console.WriteLine();
                }
            }
        }
    }
}