using System;
using StreamProgress.Models;
using StreamProgress.Models.Interfaces;

namespace StreamProgress
{
    public class Program
    {
        static void Main()
        {
            IStreamType streamType = null;

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandTokens = command
                    .Split(", ");

                if (commandTokens[0] == "Music")
                {
                    streamType = new Music(commandTokens[1], commandTokens[2], int.Parse(commandTokens[3]), int.Parse(commandTokens[4]));
                }
                else if (commandTokens[0] == "File")
                {
                    streamType = new File(commandTokens[1], int.Parse(commandTokens[3]), int.Parse(commandTokens[4]));
                }

                Console.WriteLine(streamType.ToString());
            }
        }
    }
}
