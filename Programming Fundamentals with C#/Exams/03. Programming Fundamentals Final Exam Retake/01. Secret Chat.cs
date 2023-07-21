namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input;

            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] argument = input.Split(":|:");

                if (argument[0] == "InsertSpace")
                {
                    int index = int.Parse(argument[1]);

                    string left = message.Substring(0, index);
                    string right = message.Substring(index);

                    message = left + " " + right;

                    Console.WriteLine(message);
                }

                if (argument[0] == "Reverse")
                {
                    if (message.Contains(argument[1]))
                    {
                        string reversedSubstring = string.Empty;

                        int index = message.IndexOf(argument[1]);

                        string substring = message.Substring(index, argument[1].Length);

                        message = message.Remove(index, argument[1].Length);

                        int lastIndex = message.Length - 1;

                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reversedSubstring += substring[i];
                        }

                        message = message.Insert(lastIndex + 1, reversedSubstring);

                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                if (argument[0] == "ChangeAll")
                {
                    message = message.Replace(argument[1], argument[2]);
                    Console.WriteLine(message);
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}