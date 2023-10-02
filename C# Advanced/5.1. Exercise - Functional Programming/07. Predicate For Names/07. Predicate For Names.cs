namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<string>, Predicate<string>, List<string>> predicate = (names, match) =>
            {
                List<string> result = new();

                foreach (var name in names)
                {
                    if (match(name))
                    {
                        result.Add(name);
                    }
                }

                return result;
            };

            Action<List<string>> print = finnalList =>
                Console.WriteLine(string.Join(Environment.NewLine, finnalList));

                int lenght = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> checkLength = name => name.Length <= lenght;

            names = predicate(names, checkLength);

            print(names);
        }
    }
}