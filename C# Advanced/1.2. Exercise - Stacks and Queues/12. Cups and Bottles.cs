namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] filledBottles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(cupsCapacity);
            Stack<int> bottles = new Stack<int>(filledBottles);

            int wastedLittersOfWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentCup = cups.Dequeue();
                int currentBottle = bottles.Pop();

                if (currentCup <= currentBottle)
                {
                    wastedLittersOfWater += currentBottle - currentCup;
                    continue;
                }
                else if (currentCup > currentBottle)
                {
                    currentCup -= currentBottle;

                    while (currentCup > 0)
                    {
                        currentCup -= bottles.Pop();

                        if (currentCup < 0)
                        {
                            wastedLittersOfWater += currentCup * -1;
                        }
                    }
                }
            }

            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        }
    }
}