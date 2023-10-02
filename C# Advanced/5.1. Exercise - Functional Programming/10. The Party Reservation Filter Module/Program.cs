namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Predicate<string>> filters = new();

            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] tokens = command.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (action == "Add filter")
                {
                    if (!filters.ContainsKey(filter + value))
                    {
                        filters.Add(filter + value, GetPredicate(filter, value));
                    }
                }
                else
                {
                    filters.Remove(filter + value);
                }
            }

            foreach (var filter in filters)
            {
                people.RemoveAll(filter.Value);
            }

            if (people.Any())
            {
                Console.WriteLine($"{string.Join(" ", people)}");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Starts with":
                    return p => p.StartsWith(value);
                case "Ends with":
                    return p => p.EndsWith(value);
                case "Length":
                    return p => p.Length == int.Parse(value);
                case "Contains":
                    return p => p.Contains(value);
                default:
                    return default;
            }
        }
    }
}