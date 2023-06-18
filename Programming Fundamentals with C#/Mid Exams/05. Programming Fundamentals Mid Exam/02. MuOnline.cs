namespace _02._MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;

            string[] dungeonsRooms = Console.ReadLine()
                .Split("|")
                .ToArray();
            int currentRoom = 0;
            foreach (string room in dungeonsRooms)
            {
                currentRoom++;

                string[] roomTokens = room.Split(" ")
                    .ToArray();

                string command = roomTokens[0];
                int amount = int.Parse(roomTokens[1]);

                if (command == "potion")
                {
                    if (health + amount > 100)
                    {
                        Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                    }
                    else
                    {
                        health += amount;
                        Console.WriteLine($"You healed for {amount} hp.");
                    }
                    Console.WriteLine($"Current health: {health} hp.");
                    continue;

                }

                if (command == "chest")
                {
                    bitcoins += amount;
                    Console.WriteLine($"You found {amount} bitcoins.");
                    continue;
                }

                health -= amount;
                if (health <= 0)
                {
                    Console.WriteLine($"You died! Killed by {command}.");
                    Console.WriteLine($"Best room: {currentRoom}");
                    return;
                }

                Console.WriteLine($"You slayed {command}.");
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}