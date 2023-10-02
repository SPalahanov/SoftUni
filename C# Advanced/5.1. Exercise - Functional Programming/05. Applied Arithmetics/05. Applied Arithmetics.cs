using System.Globalization;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, List<int>, List<int>> calculate = (command, numbers) =>
            {
                List<int> result = new();

                foreach (int number in numbers)
                {
                    if (command == "add")
                    {
                        result.Add(number + 1);
                    }

                    if (command == "multiply")
                    {
                        result.Add(number * 2);
                    }

                    if (command == "subtract")
                    {
                        result.Add(number - 1);
                    }
                }

                return result;
            };

            Action<List<int>> print = numbers =>
                Console.WriteLine(string.Join(" ", numbers));

            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    print(numbers);
                }
                else
                {
                    numbers = calculate(command, numbers);
                }

            }
        }
    }
}