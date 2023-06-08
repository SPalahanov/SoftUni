namespace _06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            
            while (true)
            {
                string command = Console.ReadLine();

                string[] numberOrIndex = command.Split();

                if (numberOrIndex[0] == "Add")
                {
                    numbers.Add(int.Parse(numberOrIndex[1]));
                }
                else if (numberOrIndex[0] == "Remove")
                {
                    numbers.Remove(int.Parse(numberOrIndex[1]));
                }
                else if (numberOrIndex[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(numberOrIndex[1]));
                }
                else if (numberOrIndex[0] == "Insert")
                {
                    numbers.Insert(int.Parse(numberOrIndex[2]), int.Parse(numberOrIndex[1]));
                }
                else if (numberOrIndex[0] == "end")
                {
                    break;
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}