namespace _03._P_rates
{
    internal class Program
    {
        class Town
        {
            public string Name { get; set; }

            public int Population { get; set; }

            public int Gold { get; set; }
        }

        static void Main(string[] args)
        {
            Dictionary<string, Town> townDictionary = new Dictionary<string, Town>();

            string input;

            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] townArguments = input.Split("||");

                string townName = townArguments[0];
                int population = int.Parse(townArguments[1]);
                int gold = int.Parse(townArguments[2]);

                if (!townDictionary.ContainsKey(townName))
                {
                    townDictionary.Add(townName, new Town());
                }

                townDictionary[townName].Name = townName;
                townDictionary[townName].Population += population;
                townDictionary[townName].Gold += gold;
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split("=>");

                string townName = arguments[1];

                if (arguments[0] == "Plunder")
                {
                    int killedPeople = int.Parse(arguments[2]);

                    int stolenGold = int.Parse(arguments[3]);

                    if (townDictionary.ContainsKey(townName))
                    {
                        townDictionary[townName].Population -= killedPeople;
                        townDictionary[townName].Gold -= stolenGold;

                        Console.WriteLine($"{townName} plundered! {stolenGold} gold stolen, {killedPeople} citizens killed.");

                        if (townDictionary[townName].Population <= 0 || townDictionary[townName].Gold <= 0)
                        {
                            townDictionary.Remove(townName);
                            Console.WriteLine($"{townName} has been wiped off the map!");
                        }
                    }
                }

                if (arguments[0] == "Prosper")
                {
                    int goldErnd = int.Parse(arguments[2]);

                    if (townDictionary.ContainsKey(townName))
                    {
                        if (goldErnd < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }
                        else
                        {
                            townDictionary[townName].Gold += goldErnd;
                            Console.WriteLine($"{goldErnd} gold added to the city treasury. {townName} now has {townDictionary[townName].Gold} gold.");
                        }
                    }

                }
            }

            if (townDictionary.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {townDictionary.Count} wealthy settlements to go to:");
                foreach (Town town in townDictionary.Values)
                {
                    Console.WriteLine($"{town.Name} -> Population: {town.Population} citizens, Gold: {town.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

        }
    }
}