namespace _03._Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToArray();

            string input;
            int cupidIndex = 0;

            while ((input = Console.ReadLine()) != "Love!")
            {

                int length = int.Parse(input.Split(" ")[1]);
                cupidIndex += length;

                if (cupidIndex >= neighborhood.Length)
                {
                    cupidIndex = 0;
                }

                neighborhood[cupidIndex] -= 2;

                if (neighborhood[cupidIndex] == 0)
                {
                    Console.WriteLine($"Place {cupidIndex} has Valentine's day.");
                }

                if (neighborhood[cupidIndex] < 0)
                {
                    Console.WriteLine($"Place {cupidIndex} already had Valentine's day.");
                }
            }

            Console.WriteLine($"Cupid's last position was {cupidIndex}.");

            int failedPlaces = 0;

            for (int i = 0; i < neighborhood.Length; i++)
            {
                if (neighborhood[i] > 0)
                {
                    failedPlaces++;
                }
            }

            if (failedPlaces != 0)
            {
                Console.WriteLine($"Cupid has failed {failedPlaces} places.");
                return;
            }

            Console.WriteLine("Mission was successful.");
        }
    }
}