namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (action == "Remove")
                {
                    people.RemoveAll(GetPredicate(filter, value));
                }

                if (action == "Double")
                {
                    List<string> peopleDouble = people.FindAll(GetPredicate(filter, value));

                    foreach (var person in peopleDouble)
                    {
                        int index = people.FindIndex(p => p == person);

                        people.Insert(index, person);
                    }
                }
            }

            if (people.Any())
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
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
                case "StartsWith":
                    return p => p.StartsWith(value);
                case "EndsWith":
                    return p => p.EndsWith(value);
                case "Length":
                    return p => p.Length == int.Parse(value);
                default:
                    return default;
            }
        }
    }
}