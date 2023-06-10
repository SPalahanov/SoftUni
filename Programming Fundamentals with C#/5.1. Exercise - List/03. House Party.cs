using System.Collections.Generic;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommand = int.Parse(Console.ReadLine());

            List<string> guestList = new List<string>();

            string command;

            int count = 0;

            while (count < numberOfCommand)
            {
                command = Console.ReadLine();


                string[] arguments = command.Split(" ");

                if (arguments[2] == "going!")
                {
                    guestList = AddNameToGuestList(guestList, arguments[0]);
                }
                else if (arguments[2] == "not")
                {
                    guestList = RemoveNameFromGuestList(guestList, arguments[0]);
                }


                count++;

            }
            
            Print(guestList);
        }

        static List<string> RemoveNameFromGuestList(List<string> guestList, string name)
        {
            if (guestList.Contains(name))
            {
                guestList.Remove(name);
            }
            else
            {
                Console.WriteLine($"{name} is not in the list!");
            }

            return guestList;
        }

        static List<string> AddNameToGuestList(List<string> guestList, string name)
        {
            if (!guestList.Contains(name))
            {
                guestList.Add(name);
            }
            else
            {
                Console.WriteLine($"{name} is already in the list!");
            }

            return guestList;
        }

        static void Print(List<string> guestList)
        {
            for (int i = 0; i < guestList.Count; i++)
            {
                Console.WriteLine($"{guestList[i]}");
            }
        }
    }
}