using System.Collections.Generic;

namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (firstDeck.Count > 0 && secondDeck.Count > 0)
            {
                int firstCard = firstDeck[0];
                int secondCard = secondDeck[0];

                if (firstCard > secondCard)
                {
                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                    firstDeck.Add(firstCard);
                    firstDeck.Add(secondCard);
                }
                else if (secondCard > firstCard)
                {
                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                    secondDeck.Add(secondCard);
                    secondDeck.Add(firstCard);
                }
                else if (firstCard == secondCard)
                {
                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                }
            }

            if (firstDeck.Count > secondDeck.Count)
            {
                Console.WriteLine($"First player wins! Sum: {firstDeck.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondDeck.Sum()}");
            }
        }
    }
}