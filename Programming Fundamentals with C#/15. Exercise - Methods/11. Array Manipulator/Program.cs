using System.Globalization;

namespace _11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArguments = command.Split();

                

                if (commandArguments[0] == "exchange")
                {
                    int index = int.Parse(commandArguments[1]);

                    numbers = ExchangeElements(numbers, index);
                    
                }

                if (commandArguments[0] == "max")
                {
                    string type = commandArguments[1];
                    PrintMaxIndex(numbers, type);
                }
                else if (commandArguments[0] == "min")
                {
                    string type = commandArguments[1];
                    PrintMinIndex(numbers, type);
                }
                else if (commandArguments[0] == "first")
                {
                    string type = commandArguments[2];
                    int count = int.Parse(commandArguments[1]);
                    PrintFirstElements(numbers, count, type);
                }
                else if (commandArguments[0] == "last")
                {
                    string type = commandArguments[2];
                    int count = int.Parse(commandArguments[1]);
                    PrintLastElements(numbers, count, type);
                }
            }

            Console.WriteLine($"[{string.Join(", ",numbers)}]");
        }

        static void PrintNotDefaultIndex(int maxIndex)
        {
            if (maxIndex != -1)
            {
                Console.WriteLine(maxIndex);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        static bool IsOddOrEven(string type, int number)
        {
            return (type == "even" && number % 2 == 0 || type == "odd" && number % 2 != 0);
        }

        static int[] ExchangeElements(int[] numbers, int index)
        {

            if (CheckOfOutOfRange(numbers, index))
            {
                Console.WriteLine("Invalid index");
                return numbers;
            }

            int[] changedArray = new int[numbers.Length];
            int changedArrayIndex = 0;

            for (int i = index + 1; i <= numbers.Length - 1; i++)
            {
                changedArray[changedArrayIndex++] = numbers[i];
            }

            for (int i = 0; i <= index; i++)
            {
                changedArray[changedArrayIndex++] = numbers[i];
            }

            return changedArray;

        }

        static void PrintMaxIndex(int[] numbers, string type)
        {
            int maxIndex = -1;
            int maxNumber = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                if (IsOddOrEven(type, number))
                {
                    if (number >= maxNumber)
                    {
                        maxNumber = number;
                        maxIndex = i;
                    }
                }
            }

            PrintNotDefaultIndex(maxIndex);
        }

        static void PrintMinIndex(int[] numbers, string type)
        {
            int minIndex = -1;
            int minNumber = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                if (IsOddOrEven(type, number))
                {
                    if (number <= minNumber)
                    {
                        minNumber = number;
                        minIndex = i;
                    }
                }
            }

            PrintNotDefaultIndex(minIndex);
        }

        static void PrintFirstElements(int[] numbers, int count, string type)
        {
            if (count > numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            string firstElements = " ";
            int elementsCount = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                if (IsOddOrEven(type, numbers[i]))
                {
                    firstElements += $"{number}, ";
                    elementsCount++;
                    if (elementsCount >= count)
                    {
                        break;
                    }
                }
            }


            Console.WriteLine($"[{firstElements.Trim(' ', ',')}]");
        }

        static void PrintLastElements(int[] numbers, int count, string type)
        {
            if (count > numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            string lastElement = " ";
            int elementsCount = 0;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                int number = numbers[i];
                if (IsOddOrEven(type, numbers[i]))
                {
                    lastElement = $"{number}, " + lastElement;
                    elementsCount++;
                    if (elementsCount >= count)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"[{lastElement.Trim(' ', ',')}]");
        }

        static bool CheckOfOutOfRange(int[] numbers, int index)
        {
            return index < 0 || index >= numbers.Length;
        }

    }
}
