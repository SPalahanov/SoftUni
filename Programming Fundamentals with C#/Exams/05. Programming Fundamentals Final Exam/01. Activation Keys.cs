using System;

namespace _01._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] arguments = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                if (arguments[0] == "Contains")
                {
                    if (rawActivationKey.Contains(arguments[1]))
                    {
                        Console.WriteLine($"{rawActivationKey} contains {arguments[1]}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }

                if (arguments[0] == "Flip")
                {
                    string substring = rawActivationKey.Substring(int.Parse(arguments[2]), int.Parse(arguments[3]) - int.Parse(arguments[2]));

                    rawActivationKey = rawActivationKey.Remove(int.Parse(arguments[2]), int.Parse(arguments[3]) - int.Parse(arguments[2]));

                    if (arguments[1] == "Lower")
                    {
                        substring = substring.ToLower();

                    }

                    if (arguments[1] == "Upper")
                    {
                        substring = substring.ToUpper();

                    }

                    rawActivationKey = rawActivationKey.Insert(int.Parse(arguments[2]), substring);

                    Console.WriteLine(rawActivationKey);
                }

                if (arguments[0] == "Slice")
                {
                    rawActivationKey = rawActivationKey.Remove(int.Parse(arguments[1]), int.Parse(arguments[2]) - int.Parse(arguments[1]));

                    Console.WriteLine(rawActivationKey);
                }
            }

            Console.WriteLine($"Your activation key is: {rawActivationKey}");
        }
    }
}