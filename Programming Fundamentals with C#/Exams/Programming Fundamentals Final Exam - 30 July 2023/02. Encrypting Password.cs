using System.Text.RegularExpressions;

namespace _02._Encrypting_Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string pattern = @"(.+)\>([0-9]{3})\|([a-z]{3})\|([A-Z]{3})\|([^><]+)\<\1";

                Regex regex = new Regex(pattern);

                MatchCollection matches = regex.Matches(input);

                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        string password = match.Groups[2].Value + match.Groups[3].Value + match.Groups[4].Value +
                                          match.Groups[5].Value;

                        Console.WriteLine($"Password: {password}");
                    }
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }

            }
        }
    }
}