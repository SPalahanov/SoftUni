using System.Buffers.Text;
using System.Text;
using System.Text.Unicode;

namespace Cards
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string face = tokens[0];
                string suit = tokens[1];

                try
                {
                    sb.Append(CreateCard(face, suit).ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        static Card CreateCard(string face, string suit)
        {
            string[] faces = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] suits = new[] { "H", "D", "C", "S" };

            bool equalCount = false;

            if (!faces.Any(f =>f.Equals(face)) || !suits.Any(s =>s.Equals(suit)))
            {
                throw new Exception("Invalid card!");
            }

            if (suit == "H")
            {
                char symbol = '\u2665';

                suit = symbol.ToString();
            }
            else if (suit == "S")
            {
                char symbol = '\u2660';

                suit = symbol.ToString();
            }
            else if (suit == "D")
            {
                char symbol = '\u2666';

                suit = symbol.ToString();
            }
            else if (suit == "C")
            {
                char symbol = '\u2663';

                suit = symbol.ToString();
            }

            return new Card(face, suit);
        }

    }

    class Card
    { 
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face { get; set; }

        public string Suit { get; set; }

        public override string ToString()
        {
            return $"[{Face}{Suit}] ";
        }
    }
}