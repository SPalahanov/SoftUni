namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> periodicElements = new SortedSet<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                periodicElements.UnionWith(elements);
            }

            Console.WriteLine(String.Join(" ", periodicElements));
        }
    }
}