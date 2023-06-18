namespace _02._Coffee_Lover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfCoffees = Console.ReadLine()
                .Split()
                .ToList();
            int numberOfCommand = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfCommand; i++)
            {
                string command = Console.ReadLine();

                string[] input = command.Split();

                if (input[0] == "Include")
                {
                    listOfCoffees.Add(input[1]);
                }

                if (input[0] == "Remove")
                {
                    if (input[1] == "first")
                    {
                        if (int.Parse(input[2]) < listOfCoffees.Count - 1)
                        {
                            listOfCoffees.RemoveRange(0, int.Parse(input[2]));
                        }
                    }

                    if (input[1] == "last")
                    {
                        if (int.Parse(input[2]) <= listOfCoffees.Count)
                        {
                            listOfCoffees.RemoveRange(listOfCoffees.Count - int.Parse(input[2]), int.Parse(input[2]));
                        }
                    }
                }

                if (input[0] == "Prefer")
                {
                    if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < listOfCoffees.Count &&
                        int.Parse(input[2]) > 0 && int.Parse(input[2]) < listOfCoffees.Count)
                    {
                        string temp = listOfCoffees[int.Parse(input[1])];
                        listOfCoffees[int.Parse(input[1])] = listOfCoffees[int.Parse(input[2])];
                        listOfCoffees[int.Parse(input[2])] = temp;
                    }
                }

                if (input[0] == "Reverse")
                {
                    listOfCoffees.Reverse();
                }
            }

            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(' ', listOfCoffees));
        }
    }
}