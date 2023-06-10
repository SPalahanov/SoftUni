namespace _08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> list = Console.ReadLine()
                .Split()
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] arguments = command.Split().ToArray();

                if (arguments[0] == "merge")
                {
                    int startIndex = int.Parse(arguments[1]);

                    int endIndex = int.Parse(arguments[2]);

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    else if (startIndex > list.Count - 1)
                    {
                        startIndex = list.Count - 1;
                    }

                    if (endIndex < 0)
                    {
                        endIndex = 0;
                    }
                    else if (endIndex > list.Count - 1)
                    {
                        endIndex = list.Count - 1;
                    }

                    List<string> temp = new List<string>();

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        temp.Add(list[i]);

                    }

                    list[startIndex] = string.Join("", temp);

                    for (int i = startIndex + 1; i <= endIndex; i++)
                    {
                        list.RemoveAt(startIndex + 1);

                    }
                }
                else if (arguments[0] == "divide")
                {
                    List<string> temp = new List<string>();

                    string toDivide = list[int.Parse(arguments[1])];

                    int partitions = int.Parse(arguments[2]);

                    int partLength = toDivide.Length / int.Parse(arguments[2]);

                    int additionalPartLength = toDivide.Length % int.Parse(arguments[2]);

                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1)
                        {
                            partLength += additionalPartLength;
                        }
                        temp.Add(toDivide.Substring(0, partLength));

                        toDivide = toDivide.Remove(0, partLength);
                    }

                    list.RemoveAt(int.Parse(arguments[1]));

                    list.InsertRange(int.Parse(arguments[1]), temp);
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}