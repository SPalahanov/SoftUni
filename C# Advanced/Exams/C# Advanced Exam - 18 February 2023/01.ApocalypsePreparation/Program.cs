namespace _01.ApocalypsePreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> stack = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> elements = new Dictionary<string, int>();

            int patchCounter = 0;
            int bandageCounter = 0;
            int medKitCounter = 0;

            string type;

            while (queue.Any() && stack.Any())
            {
                int textile = queue.Dequeue();
                int medicament = stack.Pop();

                int result = textile + medicament;

                if (result == 30)
                {
                    type = "Patch";
                    
                    if (!elements.ContainsKey(type))
                    {
                        elements.Add(type, patchCounter);
                    }

                    elements[type]++;
                }
                else if (result == 40)
                {
                    type = "Bandage";

                    if (!elements.ContainsKey(type))
                    {
                        elements.Add(type, bandageCounter);
                    }

                    elements[type]++;

                }
                else if (result >= 100)
                {
                    type = "MedKit";

                    if (!elements.ContainsKey(type))
                    {
                        elements.Add(type, medKitCounter);
                    }

                    elements[type]++;

                    if (result > 100)
                    {
                        int remaining = result - 100;
                        int nextElementValue = stack.Pop() + remaining;

                        stack.Push(nextElementValue);
                    }
                }
                else
                {
                    medicament += 10;
                    stack.Push(medicament);
                }
            }

            if (!queue.Any() && !stack.Any())
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (!queue.Any())
            {
                Console.WriteLine("Textiles are empty.");
            }
            else if (!stack.Any())
            {
                Console.WriteLine("Medicaments are empty.");
            }

            foreach (var element in elements.OrderByDescending(e => e.Value).ThenBy(e =>e.Key))
            {
                Console.WriteLine($"{element.Key} - {element.Value}");
            }

            if (queue.Any())
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", queue)}");
            }
            if (stack.Any())
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", stack)}");
            }
        }
    }
}