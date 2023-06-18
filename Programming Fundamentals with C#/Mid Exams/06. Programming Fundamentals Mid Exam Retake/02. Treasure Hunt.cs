namespace _02._Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split("|")
                .ToList();

            string command = string.Empty;

            double averageGain = 0;

            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] input = command.Split(' ');

                if (input[0] == "Loot")
                {
                    for (int i = 1; i < input.Length; i++)
                    {
                        if (!list.Contains(input[i]))
                        {
                            list.Insert(0, input[i]);
                        }
                    }
                }

                if (input[0] == "Drop")
                {
                    if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < list.Count)
                    {
                        string temp = list.ElementAt(int.Parse(input[1]));
                        list.RemoveAt(int.Parse(input[1]));
                        list.Add(temp);
                    }
                }

                if (input[0] == "Steal")
                {
                    List<string> stolenItems = new List<string>();
                    string text = " ";

                    if (list.Count > int.Parse(input[1]))
                    {
                        stolenItems = list.GetRange(list.Count - int.Parse(input[1]), int.Parse(input[1]));
                        list.RemoveRange(list.Count - int.Parse(input[1]), int.Parse(input[1]));
                        Console.WriteLine(string.Join(", ", stolenItems));
                    }
                    else if (list.Count <= int.Parse(input[1]))
                    {
                        stolenItems = list.GetRange(0, list.Count);
                        list.RemoveRange(0, list.Count);
                        Console.WriteLine(string.Join(", ", stolenItems));
                    }
                    
                }

                
            }

            foreach (var element in list)
            {
                averageGain += element.Length;
            }

            if (list.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                Console.WriteLine($"Average treasure gain: {(averageGain / (list.Count)):f2} pirate credits.");
            }
        }
    }
}