namespace _04._SoftUni_Parking
{
    class User
    {
        public string Name { get; set; }

        public string LicensePlate { get; set; }

        public User(string name, string licensePlate)
        {
            Name = name;
            LicensePlate = licensePlate;
        }

        public override string ToString()
        {
            return $"{Name} => {LicensePlate} ";
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, User> database = new Dictionary<string, User>();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] arguments = Console.ReadLine().Split();

                string command = arguments[0];
                string userName = arguments[1];
                

                switch (command)
                {
                    case "register":
                        string licensePlate = arguments[2];
                        User newUser = new User(userName, licensePlate);
                        if (!database.ContainsKey(newUser.Name))
                        {
                            database.Add(newUser.Name, newUser);
                            Console.WriteLine($"{newUser.Name} registered {newUser.LicensePlate} successfully");
                        }
                        else
                        {
                            User foundUser = database[newUser.Name];
                            Console.WriteLine($"ERROR: already registered with plate number {newUser.LicensePlate}");
                        }
                        break;
                    case "unregister":

                        if (!database.ContainsKey(userName))
                        {
                            Console.WriteLine($"ERROR: user {userName} not found");
                        }
                        else
                        {
                            database.Remove(userName);
                            Console.WriteLine($"{userName} unregistered successfully");
                        }
                        break;
                }
            }
            
            foreach (var kvp in database)
            {
                Console.WriteLine(kvp.Value.ToString());
            }
        }
    }
}