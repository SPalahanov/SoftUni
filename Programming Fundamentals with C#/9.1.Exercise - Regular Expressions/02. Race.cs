using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine()
                .Split(", ")
                .ToList();

            Dictionary<string, int> racers = new Dictionary<string, int>();

            string input;

            string pattern = @"(?<Name>[A-Za-z]+)|(?<Numbers>\d+)";

            while ((input = Console.ReadLine()) != "end of race")
            {
                Regex regex = new Regex(pattern);

                MatchCollection matches = regex.Matches(input);

                string numbers = String.Empty;

                string name = String.Empty;

                foreach (Match match in matches)
                {
                    name += match.Groups["Name"].Value;

                    numbers += match.Groups["Numbers"].Value;
                }
                
                int num = int.Parse(numbers);

                int sum = 0;

                while (num != 0)
                {
                    sum += num % 10;
                    num /= 10;
                }
                
                if (participants.Contains(name))
                {
                    if (racers.ContainsKey(name))
                    {
                        racers[name] += sum;
                    }
                    else
                    {
                        racers.Add(name, sum);
                        
                    }
                }

            }

            racers = racers.OrderByDescending(r => r.Value)
                .ToDictionary(r => r.Key, r => r.Value);

            Console.WriteLine($"1st place: {racers.Keys.ElementAt(0)}");

            Console.WriteLine($"2nd place: {racers.Keys.ElementAt(1)}");

            Console.WriteLine($"3rd place: {racers.Keys.ElementAt(2)}");
        }
    }
}