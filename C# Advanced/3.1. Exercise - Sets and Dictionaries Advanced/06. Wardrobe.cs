namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new();
            
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] {" -> ", ","}, StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 1; j < input.Length; j++)
                {
                    string item = input[j];

                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }

                    wardrobe[color][item]++;
                }
            }

            string[] findParams = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

           foreach (var clothes in wardrobe)
            {
                Console.WriteLine($"{clothes.Key} clothes:");

                foreach (var kvp in clothes.Value)
                {
                    string toPrint = $"* {kvp.Key} - {kvp.Value}";
                    
                    string color = findParams[0];
                    string item = findParams[1];
                    
                    if (clothes.Key == color && kvp.Key == item)
                    {
                        toPrint += " (found!)";
                    }
                    
                    Console.WriteLine(toPrint);
                }
            }
        }
    }
}