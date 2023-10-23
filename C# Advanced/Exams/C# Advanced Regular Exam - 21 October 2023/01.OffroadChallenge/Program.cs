using System.ComponentModel.Design;
using System.Text;

namespace OffroadChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> fuels = new Stack<int>(Console.ReadLine()
                    .Split()
                    .Select(int.Parse));

            Queue<int> consumptions = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            Queue<int> neededQuantities = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            List<int> reachedAltitude = new List<int>();
            
            int altitudeCount = 0;

            while (fuels.Any() && consumptions.Any())
            {
                int fuel = fuels.Pop();
                int consumption = consumptions.Dequeue();
                int result = fuel - consumption;

                altitudeCount++;

                if (result >= neededQuantities.Peek())
                {
                    neededQuantities.Dequeue();
                    reachedAltitude.Add(altitudeCount);

                    Console.WriteLine($"John has reached: Altitude {altitudeCount}");
                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {altitudeCount}");

                    Console.WriteLine("John failed to reach the top.");

                    if (reachedAltitude.Any())
                    {
                        StringBuilder sb = new StringBuilder();

                        sb.Append("Reached altitudes: ");

                        foreach (var item in reachedAltitude)
                        {
                            sb.Append($"Altitude {item}, ");
                        }

                        Console.WriteLine(sb.ToString().TrimEnd(',', ' '));
                    }
                    else
                    {
                        Console.WriteLine("John didn't reach any altitude.");
                    }

                    return;
                }
            }

            if (!neededQuantities.Any())
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }
        }
    }
}