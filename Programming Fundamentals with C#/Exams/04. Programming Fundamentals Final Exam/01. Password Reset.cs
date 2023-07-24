using System.Text;

namespace _01._Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "Done")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (arguments[0] == "TakeOdd")
                {
                    StringBuilder newRawPassword = new StringBuilder();

                    for (int i = 1; i < password.Length; i += 2)
                    {
                        newRawPassword.Append(password[i]);
                    }

                    password = newRawPassword.ToString();
                    Console.WriteLine(password);
                }

                if (arguments[0] == "Cut")
                {
                    password = password.Remove(int.Parse(arguments[1]), int.Parse(arguments[2]));

                    Console.WriteLine(password);
                }

                if (arguments[0] == "Substitute")
                {
                    if (password.Contains(arguments[1]))
                    {
                        password = password.Replace(arguments[1], arguments[2]);

                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}