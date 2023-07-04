namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = " ";

            Dictionary<string, int> resources = new Dictionary<string, int>();
            while ((key = Console.ReadLine()) != "stop")
            {
                int valueInput = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(key))
                {
                    resources.Add(key, valueInput);
                }
                else
                {
                    resources[key] += valueInput;
                }
            }

            foreach (var kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}