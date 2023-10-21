using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> white = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> grey = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> locations = new Dictionary<string, int>();

            int countertopTiles = 0;
            int flootTiles = 0;
            int ovenTiles = 0;
            int sinkTiles = 0;
            int wallTiles = 0;

            while (white.Any() && grey.Any())
            {
                int whiteTiles = white.Pop();
                int greyTiles = grey.Dequeue();

                if (whiteTiles == greyTiles)
                {
                    if (whiteTiles + greyTiles == 40)
                    {
                        if (!locations.ContainsKey("Sink"))
                        {
                            locations.Add("Sink", sinkTiles);
                        }

                        sinkTiles++;
                        locations["Sink"] = sinkTiles;

                    }
                    else if (whiteTiles + greyTiles == 50)
                    {
                        if (!locations.ContainsKey("Oven"))
                        {
                            locations.Add("Oven", ovenTiles);
                        }

                        ovenTiles++;
                        locations["Oven"] = ovenTiles;
                    }
                    else if (whiteTiles + greyTiles == 60)
                    {
                        if (!locations.ContainsKey("Countertop"))
                        {
                            locations.Add("Countertop", countertopTiles);
                        }

                        countertopTiles++;
                        locations["Countertop"] = countertopTiles;
                    }
                    else if (whiteTiles + greyTiles == 70)
                    {
                        if (!locations.ContainsKey("Wall"))
                        {
                            locations.Add("Wall", wallTiles);
                        }

                        wallTiles++;
                        locations["Wall"] = wallTiles;
                    }
                    else
                    {
                        if (!locations.ContainsKey("Floor"))
                        {
                            locations.Add("Floor", flootTiles);
                        }

                        flootTiles++;
                        locations["Floor"] = flootTiles;
                    }
                }
                else
                {
                    white.Push(whiteTiles / 2);
                    grey.Enqueue(greyTiles);
                }
            }

            if (white.Any())
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", white)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (grey.Any())
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grey)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var location in locations.OrderByDescending(l => l.Value).ThenBy(l => l.Key))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}
