namespace Problem_06._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "Craft!")
            {
                string[] text = command.Split(" - ");

                if (text[0] == "Collect")
                {
                    if (!list.Contains(text[1]))
                    {
                        list.Add(text[1]);
                    }
                    
                }

                if (text[0] == "Drop")
                {
                    if (list.Contains(text[1]))
                    {
                        list.Remove(text[1]);
                    }

                }

                if (text[0] == "Combine Items")
                {
                    string[] itemsToCombine = text[1].Split(":", StringSplitOptions.RemoveEmptyEntries);

                    int index = list.IndexOf(itemsToCombine[0]);

                    if (list.Contains(itemsToCombine[0]))
                    {
                        
                        list.Insert(index + 1, itemsToCombine[1]);
                    }
                }

                if (text[0] == "Renew")
                {
                    if (list.Contains(text[1]))
                    {
                        list.Remove(text[1]);
                        list.Add(text[1]);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}