using System.ComponentModel.Design;

namespace BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffee = new(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));

            Stack<int> milk = new(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));

            Dictionary<string, int> drinks = new Dictionary<string, int>();

            int cortadoCount = 0;
            int espressoCount = 0;
            int capuccinoCount = 0;
            int americanoCount = 0;
            int latteCount = 0;

            while (coffee.Any() && milk.Any())
            {
                int takenMilk = milk.Pop();
                int result = coffee.Dequeue() + takenMilk;

                if (result == 50)
                {
                    if (!drinks.ContainsKey("Cortado"))
                    {
                        drinks.Add("Cortado", cortadoCount);
                    }

                    cortadoCount++;
                    drinks["Cortado"] = cortadoCount;

                    continue;
                }

                if (result == 75)
                {
                    if (!drinks.ContainsKey("Espresso"))
                    {
                        drinks.Add("Espresso", espressoCount);
                    }

                    espressoCount++;
                    drinks["Espresso"] = espressoCount;
                    continue;
                }

                if (result == 100)
                {
                    if (!drinks.ContainsKey("Capuccino"))
                    {
                        drinks.Add("Capuccino", capuccinoCount);
                    }

                    capuccinoCount++;
                    drinks["Capuccino"] = capuccinoCount;
                    continue;
                }

                if (result == 150)
                {
                    if (!drinks.ContainsKey("Americano"))
                    {
                        drinks.Add("Americano", americanoCount);
                    }

                    americanoCount++;
                    drinks["Americano"] = americanoCount;
                    continue;
                }

                if (result == 200)
                {
                    if (!drinks.ContainsKey("Latte"))
                    {
                        drinks.Add("Latte", latteCount);
                    }

                    latteCount++;
                    drinks["Latte"] = latteCount;
                    continue;
                }

                milk.Push(takenMilk - 5);
            }

            if (coffee.Count == 0 && milk.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffee.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }

            if (milk.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }

            foreach (var drink in drinks.OrderBy(d =>d.Value).ThenByDescending(d =>d.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}