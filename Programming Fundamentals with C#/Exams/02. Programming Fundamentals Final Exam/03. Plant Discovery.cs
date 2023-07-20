namespace _03._Plant_Discovery
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Plant> plants = new List<Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split("<->");

                string name = tokens[0];

                int rarity = int.Parse(tokens[1]);

                if (plants.Any(x => x.Name == name))
                {
                    plants.FirstOrDefault(x => x.Name == name).Rarity = rarity;
                }
                else
                {
                    plants.Add(new Plant(name, rarity));
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] arguments = command
                    .Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);
                string plantName = arguments[1];

                if (!plants.Any(x => x.Name == plantName))
                {
                    Console.WriteLine("error");
                    continue;
                }

                if (arguments[0] == "Rate")
                {
                    int rating = int.Parse(arguments[2]);

                    plants.First(x => x.Name == plantName).Ratings.Add(rating);
                }
                else if (arguments[0] == "Update")
                {
                    int rarity = int.Parse(arguments[2]);

                    plants.First(x => x.Name == plantName).Rarity = rarity;
                }
                else if (arguments[0] == "Reset")
                {
                    plants.First(x => x.Name == plantName).Ratings = new List<int>();
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants)
            {
                double rating = 0.0;

                if (plant.Ratings.Any())
                {
                    rating = plant.Ratings.Average();
                }
                Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {rating:f2}");
            }
        }
    }

    public class Plant
    {
        public string Name { get; set; }

        public int Rarity { get; set; }

        public List<int> Ratings { get; set; }

        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            Ratings = new List<int>();
        }
    }
}