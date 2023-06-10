using System.Globalization;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = " ";

            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split(' ');

                if (arguments[0] == "Delete")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == int.Parse(arguments[1]))
                        {
                            numbers.RemoveAt(i);
                        }
                    }
                }
                else if (arguments[0] == "Insert")
                {
                    numbers = InsertElementAtIndex(numbers, int.Parse(arguments[1]), int.Parse(arguments[2]));
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static List<int> InsertElementAtIndex(List<int> numbers, int element, int position)
        {
            numbers.Insert(position, element);
            
            return numbers;
        } 
    }
}