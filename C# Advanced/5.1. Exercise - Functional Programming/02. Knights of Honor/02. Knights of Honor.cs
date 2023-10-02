namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string, string[]> printNamesWithAddedTitle = (title, names) =>
            {
                foreach (var name in names)
                {
                    Console.WriteLine($"{title} {name}");
                }
            };

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            printNamesWithAddedTitle("Sir", input);
        }
    }
}