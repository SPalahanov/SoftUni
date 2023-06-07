namespace _07.ConcatNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name1 = Console.ReadLine();
            string name2 = Console.ReadLine();
            string symbol = Console.ReadLine();

            Console.WriteLine($"{name1}{symbol}{name2}");
        }
    }
}