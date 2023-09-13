namespace _01._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "Complete")
            {
                string[] arguments = command.Split(" ");

                if (arguments[0] == "Make")
                {
                    int index = int.Parse(arguments[2]);
                    
                    if (arguments[1] == "Upper")
                    {
                        string letter = password.Substring(index, 1);
                        letter = letter.ToUpper();
                        password = password.Remove(index, 1);
                        password = password.Insert(index, letter);
                        
                        Console.WriteLine(password);
                    }

                    if (arguments[1] == "Lower")
                    {
                        string letter = password.Substring(index, 1);
                        letter = letter.ToLower();
                        password = password.Remove(index, 1);
                        password = password.Insert(index, letter);

                        Console.WriteLine(password);
                    }
                }
                 
                if (arguments[0] == "Insert")
                {
                    int index = int.Parse(arguments[1]);
                    string value = arguments[2];

                    if (index >=0 && index < password.Length)
                    {
                        password = password.Insert(index, value);

                        Console.WriteLine(password);
                    }
                }

                if (arguments[0] == "Replace")
                {
                    char givenChar = char.Parse(arguments[1]);
                    int value = int.Parse(arguments[2]);

                    if (password.Contains(givenChar))
                    {
                        int newSymbolNumber = givenChar + value;

                        char newSymbol = (char)newSymbolNumber;

                        password = password.Replace(givenChar, newSymbol);

                        Console.WriteLine(password);
                    }
                }

                if (arguments[0] == "Validation")
                {
                    if (password.Length < 8)
                    {
                        Console.WriteLine("Password must be at least 8 characters long!");
                    }

                    if (!password.All(x => Char.IsLetterOrDigit(x) || x == '_'))
                    {
                        Console.WriteLine("Password must consist only of letters, digits and _!");
                    }

                    if (!password.Any(x => Char.IsUpper(x)))
                    {
                        Console.WriteLine("Password must consist at least one uppercase letter!");
                    }

                    if (!password.Any(x => Char.IsLower(x)))
                    {
                        Console.WriteLine("Password must consist at least one lowercase letter!");
                    }

                    if (!password.Any(x => Char.IsDigit(x)))
                    {
                        Console.WriteLine("Password must consist at least one digit!");
                    }
                }
            }
        }
    }
}