namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";
            int attempt = 0;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            //Console.WriteLine(password);  - Correct password

            string userInput = "";

            while ((userInput = Console.ReadLine()) != password)
            {
                
                if (userInput != password)
                {
                    if (attempt == 3)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        return;
                    }
                }

                Console.WriteLine("Incorrect password. Try again.");
                attempt++;
            }

            if (userInput == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}