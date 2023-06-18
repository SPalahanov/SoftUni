namespace _02._Shopping_Lis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split("!")
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] input = command.Split(' ');

                if (input[0] == "Urgent")
                {
                    if (!list.Contains(input[1]))
                    {
                        list.Insert(0, input[1]);
                    }
                }

                if (input[0] == "Unnecessary")
                {
                    if (list.Contains(input[1]))
                    {
                        list.Remove(input[1]);
                    }
                }

                if (input[0] == "Correct")
                {
                    if (list.Contains(input[1]))
                    {
                        int temp = list.IndexOf(input[1]);
                        list.Remove(input[1]);
                        list.Insert(temp, input[2]);
                    }
                }

                if (input[0] == "Rearrange")
                {
                    if (list.Contains(input[1]))
                    {
                        list.Remove(input[1]);
                        list.Add(input[1]);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}