namespace _03._Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();

            List<int> warship = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();

            int maximumHealthCapacity = int.Parse(Console.ReadLine());

            string command = String.Empty;

            int zeroCounter = 0;

            while ((command = Console.ReadLine()) != "Retire")
            {
                string[] input = command.Split(" ");
                
                if (input[0] == "Fire")
                {
                    if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < warship.Count)
                    {
                        warship[int.Parse(input[1])] -= int.Parse(input[2]);

                        if (warship[int.Parse(input[1])] <= 0)
                        {
                            zeroCounter++;
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            break;
                        }
                    }
                }

                if (input[0] == "Defend")
                {
                    if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < pirateShip.Count && 
                        int.Parse(input[2]) >= 0 && int.Parse(input[2]) < pirateShip.Count)
                    {
                        for (int i = int.Parse(input[1]); i <= int.Parse(input[2]); i++)
                        {
                            pirateShip[i] -= int.Parse(input[3]);

                            if (pirateShip[i] <= 0)
                            {
                                zeroCounter++;
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                break;
                            }
                        }
                    }

                }

                if (input[0] == "Repair")
                {
                    if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < pirateShip.Count)
                    {
                        pirateShip[int.Parse(input[1])] += int.Parse(input[2]);

                        if (pirateShip[int.Parse(input[1])] > maximumHealthCapacity)
                        {
                            pirateShip[int.Parse(input[1])] = maximumHealthCapacity;
                        }
                    }

                }


                if (input[0] == "Status")
                {
                    int count = 0;
                    
                    
                    for (int i = 0; i < pirateShip.Count; i++)
                    {
                        if (pirateShip[i] < maximumHealthCapacity * 0.2)
                        {
                            count++;
                        }
                    }

                    Console.WriteLine($"{count} sections need repair.");
                }
            }

            if (zeroCounter == 0)
            {
                int pirateShipSum = 0;
                int warshipSum = 0;

                foreach (int num in pirateShip)
                {
                    pirateShipSum += num;
                }

                foreach (int num in warship)
                {
                    warshipSum += num;
                }

                Console.WriteLine($"Pirate ship status: {pirateShipSum}");
                Console.WriteLine($"Warship status: {warshipSum}");
            }
        }
    }
}