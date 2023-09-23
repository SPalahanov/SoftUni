namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continentsDictionary =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = command[0];
                string country = command[1];
                string city = command[2];

                if (!continentsDictionary.ContainsKey(continent))
                {
                    continentsDictionary.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continentsDictionary[continent].ContainsKey(country))
                {
                    continentsDictionary[continent][country] = new List<string>();
                }
                continentsDictionary[continent][country].Add(city);
            }

            foreach (var continent in continentsDictionary)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var kvp in continent.Value)
                {
                    Console.WriteLine($" {kvp.Key} -> {String.Join(", ", kvp.Value)}");
                }
            }
        }
    }
}