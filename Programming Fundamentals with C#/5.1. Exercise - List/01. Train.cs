using System.Collections.Generic;
using System.Data;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string command = " ";

            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split();

                if (arguments[0] == "Add")
                {
                    wagons.Add(int.Parse(arguments[1]));
                }
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (int.Parse(arguments[0]) + wagons[i] <= maxCapacity)
                        {
                            wagons[i] += int.Parse(arguments[0]);
                            break;
                        }
                    }
                }

                
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}