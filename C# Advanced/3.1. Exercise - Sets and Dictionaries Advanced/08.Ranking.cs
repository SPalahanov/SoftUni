using System.Xml.Linq;

namespace _08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsPasswords = new();
            SortedDictionary<string, Dictionary<string, int>> candidatesStats = new();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = input.Split(":");

                string contest = tokens[0];
                string password = tokens[1];

                contestsPasswords.Add(contest, password);
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = input.Split("=>");

                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contestsPasswords.ContainsKey(contest) && contestsPasswords[contest] == password)
                {
                    if (!candidatesStats.ContainsKey(username))
                    {
                        candidatesStats.Add(username, new Dictionary<string, int>());
                    }

                    if (!candidatesStats[username].ContainsKey(contest))
                    {
                        candidatesStats[username].Add(contest, 0);
                    }

                    if (candidatesStats[username][contest] < points)
                    {
                        candidatesStats[username][contest] = points;
                    }
                }
            }

            string bestCandidate = candidatesStats.MaxBy(x => x.Value.Values.Sum()).Key;

            int bestCandidatePoints = candidatesStats[bestCandidate].Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidatePoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var candidateStats in candidatesStats)
            {
                Console.WriteLine(candidateStats.Key);

                Dictionary<string, int> orderedByPointsDesc = candidateStats.Value
                    .OrderByDescending(c => c.Value)
                    .ToDictionary(c => c.Key, c => c.Value);

                foreach (var kvp in orderedByPointsDesc)
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}