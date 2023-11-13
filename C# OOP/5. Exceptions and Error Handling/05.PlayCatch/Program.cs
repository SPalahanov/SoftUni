using System;

namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int exCount = 0;

            while (exCount != 3)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (command[0] == "Replace")
                    {
                        int index = int.Parse(command[1]);
                        int element = int.Parse(command[2]);

                        if (index > numbers.Count || index < 0)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }

                        Convert.ToInt32(element);
                        
                        numbers.RemoveAt(index);
                        numbers.Insert(index, element);
                    }

                    if (command[0] == "Print")
                    {
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);

                        if (startIndex > numbers.Count || startIndex < 0 || endIndex > numbers.Count - 1 || endIndex < 0)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }

                        List<int> range = numbers.GetRange(startIndex, endIndex + 1 - startIndex);

                        Console.WriteLine(string.Join(", ", range));

                    }

                    if (command[0] == "Show")
                    {
                        int index = int.Parse(command[1]);

                        if (index > numbers.Count || index < 0)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }

                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);

                    exCount++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");

                    exCount++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}