using System.Threading.Channels;

namespace _07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pourCount = int.Parse(Console.ReadLine());
            int volum = 0;

            for (int i = 1; i <= pourCount; i++)
            {
                int quantitiesOfWater = int.Parse(Console.ReadLine());
                volum += quantitiesOfWater;

                if (volum > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    volum -= quantitiesOfWater;
                }
            }
            Console.WriteLine(volum);
        }
    }
}