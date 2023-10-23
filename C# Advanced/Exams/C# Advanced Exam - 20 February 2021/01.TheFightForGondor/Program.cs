using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> orcsLeft = new Stack<int>();

            bool isPlateDestroyed = false;

            for (int i = 1; i <= numberOfWaves; i++)
            {

                Stack<int> orcs = new Stack<int>(Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());

                    plates.Enqueue(newPlate);
                }

                while (orcs.Any() && plates.Any())
                {
                    if (orcs.Peek() > plates.Peek())
                    {
                        orcs.Push(orcs.Pop() - plates.Dequeue());
                    }
                    else if (plates.Peek() > orcs.Peek())
                    {
                        Queue<int> newPlates = new Queue<int>();

                        newPlates.Enqueue(plates.Dequeue() - orcs.Pop());

                        for (int j = 0; j < plates.Count; j++)
                        {
                            newPlates.Enqueue(plates.ElementAt(j));
                        }

                        plates = newPlates;
                    }
                    else
                    {
                        plates.Dequeue();
                        orcs.Pop();
                    }

                    if (!plates.Any())
                    {
                        isPlateDestroyed = true;
                        orcsLeft = orcs;
                        break;
                    }
                }
            }

            if (isPlateDestroyed)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");

                Console.WriteLine($"Orcs left: {string.Join(", ", orcsLeft)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");

                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
