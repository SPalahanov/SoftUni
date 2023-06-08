using System;
using System.Runtime.CompilerServices;

namespace _07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] initialNumbers = new int[numbers.Count];

            numbers.CopyTo(initialNumbers);

            while (true)
            {
                string command = Console.ReadLine();

                string[] numberOrIndex = command.Split();


                if (command == "end")
                {
                    bool areEqual = Enumerable.SequenceEqual(numbers, initialNumbers);

                    if (!areEqual)
                    {
                        Console.WriteLine(string.Join(" ", numbers));
                    }

                    return;
                }


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
                else if (numberOrIndex[0] == "Contains")
                {
                    bool isTrue = numbers.Contains(int.Parse(numberOrIndex[1]));

                    if (isTrue)
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }

                }
                else if (numberOrIndex[0] == "PrintEven")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 == 0)
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 0)));
                            break;
                        }
                    }
                }
                else if (numberOrIndex[0] == "PrintOdd")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 != 0)
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 != 0)));
                            break;
                        }
                    }
                }
                else if (numberOrIndex[0] == "GetSum")
                {
                    Console.WriteLine(string.Join(" ", numbers.Sum()));

                }
                else if (numberOrIndex[0] == "Filter")
                {
                    if (numberOrIndex[1] == "<=")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x <= int.Parse(numberOrIndex[2]))));
                            break;
                        }
                    }
                    else if (numberOrIndex[1] == ">=")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x >= int.Parse(numberOrIndex[2]))));
                            break;
                        }
                    }
                    else if (numberOrIndex[1] == "<")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x < int.Parse(numberOrIndex[2]))));
                            break;
                        }
                    }
                    else if (numberOrIndex[1] == ">")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x > int.Parse(numberOrIndex[2]))));
                            break;
                        }
                    }
                }
            }
        }
    }
}