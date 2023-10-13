using System.Reflection.Metadata;

namespace Params_Keyword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintName("pesho", "Gosho", "1", "2");

            PrintValues("All values are below:", 5, DateTime.Now, "", CancellationToken.None);

            PrintT<int>(1, 2, 3, 4);
            PrintT<decimal>(1.0m, 2.0m, 3.0m);
        }

        static void PrintName(params string[] names)
        {
            Console.WriteLine(string.Join(" ", names));
        }

        static void PrintValues(string header, params object[] values)
        {
            Console.WriteLine(header);

            foreach (var item in header)
            {
                Console.Write(values + " ");
            }
        }

        static void PrintT<T>(params T[] values)
        {
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
        }
    }
}