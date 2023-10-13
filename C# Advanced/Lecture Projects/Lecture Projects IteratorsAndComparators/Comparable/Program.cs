namespace Comparable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 5;

            int b = 100;

            Console.WriteLine(a.CompareTo(b));
            Console.WriteLine(b.CompareTo(a));
            Console.WriteLine(5.CompareTo(5));
        }
    }
}