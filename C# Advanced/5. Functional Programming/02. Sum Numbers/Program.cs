using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Sum());
        }
    }
}