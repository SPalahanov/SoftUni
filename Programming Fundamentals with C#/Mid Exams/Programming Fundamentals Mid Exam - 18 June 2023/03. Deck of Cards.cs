namespace _03._Deck_of_Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> deckOfCards = Console.ReadLine()
                .Split(", ")
                .ToList();

            int numberOfCommand = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfCommand; i++)
            {
                string commands = Console.ReadLine();

                string[] input = commands.Split(", ");

                if (input[0] == "Add")
                {
                    if (deckOfCards.Contains(input[1]))
                    {
                        Console.WriteLine("Card is already in the deck");
                    }
                    else
                    {
                        deckOfCards.Add(input[1]);

                        Console.WriteLine("Card successfully added");
                    }
                }

                if (input[0] == "Remove")
                {
                    if (deckOfCards.Contains(input[1]))
                    {
                        deckOfCards.Remove(input[1]);
                        
                        Console.WriteLine("Card successfully removed");
                    }
                    else
                    {
                        Console.WriteLine("Card not found");
                    }
                }

                if (input[0] == "Remove At")
                {
                    if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < deckOfCards.Count)
                    {
                        deckOfCards.RemoveAt(int.Parse(input[1]));

                        Console.WriteLine("Card successfully removed");
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }

                if (input[0] == "Insert")
                {
                    if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < deckOfCards.Count)
                    {
                        if (!deckOfCards.Contains(input[2]))
                        {
                            deckOfCards.Insert(int.Parse(input[1]), input[2]);

                            Console.WriteLine("Card successfully added");
                        }
                        else
                        {
                            Console.WriteLine("Card is already added");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
            }

            Console.WriteLine(string.Join(", ", deckOfCards));
        }
    }
}