namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int petrolPump = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < petrolPump; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int petrol = input[0];
                int distance = input[1];

                pumps.Enqueue(input);
            }

            int bestRoute = 0;

            while (true)
            {
                int totalPetrol = 0;

                foreach (int[] pump in pumps)
                {
                    totalPetrol += pump[0];
                    int currentDistance = pump[1];

                    if (totalPetrol - currentDistance < 0)
                    {
                        totalPetrol = -1;
                        break;
                    }
                    else
                    {
                        totalPetrol -= currentDistance;
                    }
                }

                if (totalPetrol >= 0)
                {
                    break;
                }

                bestRoute++;

                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(bestRoute);




            //=================/ Second Solution /===============//


            //int petrolPump = int.Parse(Console.ReadLine());

            //Queue<(int, int)> pumps = new Queue<(int, int)>();

            //for (int i = 0; i < petrolPump; i++)
            //{
            //    int[] input = Console.ReadLine()
            //        .Split()
            //        .Select(int.Parse)
            //        .ToArray();

            //    int petrol = input[0];
            //    int distance = input[1];

            //    pumps.Enqueue((petrol, distance));
            //}

            //int bestRoute = 0;

            //while (true)
            //{
            //    int totalPetrol = 0;

            //    foreach ((int, int) pump in pumps)
            //    {
            //        totalPetrol += pump.Item1;
            //        int currentDistance = pump.Item2;

            //        if (totalPetrol - currentDistance < 0)
            //        {
            //            totalPetrol = -1;
            //            break;
            //        }
            //        else
            //        {
            //            totalPetrol -= currentDistance;
            //        }
            //    }

            //    if (totalPetrol >= 0)
            //    {
            //        break;
            //    }

            //    bestRoute++;

            //    pumps.Enqueue(pumps.Dequeue());
            //}

            //Console.WriteLine(bestRoute);
        }
    }
}