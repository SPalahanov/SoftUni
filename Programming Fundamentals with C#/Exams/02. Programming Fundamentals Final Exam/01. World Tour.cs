namespace _01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] arguments = command.Split(":", StringSplitOptions.RemoveEmptyEntries);

                if (arguments[0] == "Add Stop")
                {
                    if (int.Parse(arguments[1]) >= 0 && int.Parse(arguments[1]) <= stops.Length - 1)
                    {
                        stops = stops.Insert(int.Parse(arguments[1]), arguments[2]);
                    }

                    Console.WriteLine(stops);
                }

                if (arguments[0] == "Remove Stop")
                {
                    if (int.Parse(arguments[1]) >= 0 && int.Parse(arguments[1]) <= stops.Length - 1 && int.Parse(arguments[2]) >= 0 && int.Parse(arguments[2]) <= stops.Length - 1)
                    {
                        stops = stops.Remove(int.Parse(arguments[1]), int.Parse(arguments[2]) + 1 - int.Parse(arguments[1]));
                    }

                    Console.WriteLine(stops);
                }

                if (arguments[0] == "Switch")
                {
                    if (stops.Contains(arguments[1]))
                    {
                        stops = stops.Replace(arguments[1], arguments[2]);
                    }

                    Console.WriteLine(stops);
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}