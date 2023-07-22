namespace _01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] commandInfo = command
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string commandName = commandInfo[0];

                if (commandName == "Move")
                {
                    string substring = message.Substring(0, int.Parse(commandInfo[1]));

                    message = message.Remove(0, substring.Length);

                    message += substring;
                }

                if (commandName == "Insert")
                {
                    message = message.Insert(int.Parse(commandInfo[1]), commandInfo[2]);
                }

                if (commandName == "ChangeAll")
                {
                    message = message.Replace(commandInfo[1], commandInfo[2]);
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}