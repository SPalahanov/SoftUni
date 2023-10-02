using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> parser = s => double.Parse(s);
            Func<double, double> vat = n =>  n * 1.2;

            List<double> numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .Select(vat)
            .ToList();

            foreach (var number in numbers)
            {
                Console.WriteLine($"{(number):f2}");
            }
        }
    }
}