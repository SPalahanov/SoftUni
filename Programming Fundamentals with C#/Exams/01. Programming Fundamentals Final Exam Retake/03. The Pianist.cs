namespace _03._The_Pianist
{
    internal class Program
    {
        class Piece
        {
            public Piece(string composer, string key)
            {
                Composer = composer;
                Key = key;
            }

            public string Name { get; set; }

            public string Composer { get; set; }

            public string Key { get; set; }
        }
        
        static void Main(string[] args)
        {
            Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|");

                string name = input[0];
                string composer = input[1];
                string key = input[2];

                Piece piece = new Piece(composer, key);

                pieces[name] = piece;
            }

            string command;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] arguments = command.Split("|");

                string pieceName = arguments[1];

                if (arguments[0] == "Add")
                {
                    string composer = arguments[2];
                    string key = arguments[3];
                    
                    if (!pieces.ContainsKey(pieceName))
                    {
                        pieces.Add(pieceName, new Piece(composer, key));

                        Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                    }
                }

                if (arguments[0] == "Remove")
                {
                    if (pieces.ContainsKey(pieceName))
                    { 
                        pieces.Remove(pieceName);

                        Console.WriteLine($"Successfully removed {pieceName}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }

                if (arguments[0] == "ChangeKey")
                {
                    string newKey = arguments[2];
                    
                    if (pieces.ContainsKey(pieceName))
                    {
                        pieces[pieceName].Key = newKey;

                        Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
            }

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
    }
}