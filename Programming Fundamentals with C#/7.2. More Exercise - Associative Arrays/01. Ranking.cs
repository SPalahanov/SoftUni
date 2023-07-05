namespace _01._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string input1;

            while ((input1 = Console.ReadLine()) != "end of contests")
            {
                string[] arguments = input1.Split(":");

                string contestName = arguments[0];
                string contestPassword = arguments[1];

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, contestPassword);
                }
            }

            SortedDictionary<string, SortedDictionary<string, int>> submissions = new SortedDictionary<string, SortedDictionary<string, int>>();

            string input2;

            while ((input2 = Console.ReadLine()) != "end of submissions")
            {
                string[] arguments = input2.Split("=>");

                string contestName = arguments[0];
                string contestPassword = arguments[1];
                string userName = arguments[2];
                int points = int.Parse(arguments[3]);

                if (contests.ContainsValue(contestPassword))
                {
                    if (!submissions.ContainsKey(userName))
                    {
                        submissions[userName] = new SortedDictionary<string, int>();

                    }

                    if (!submissions[userName].ContainsKey(contestName))
                    {
                        submissions[userName].Add(contestName, points);
                    }

                    if (!submissions[userName].ContainsKey(contestName))
                    {
                        submissions[userName][contestName] = points;
                    }
                    else
                    {
                        submissions[userName][contestName] = Math.Max(submissions[userName][contestName], points);
                    }
                }
            }

            string bestUser = string.Empty;
            int bestTotalPoints = 0;

            foreach (var user in submissions)
            {
                int totalPoints = user.Value.Values.Sum();
                if (totalPoints > bestTotalPoints)
                {
                    bestUser = user.Key;
                    bestTotalPoints = totalPoints;
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {bestTotalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var submission in submissions)
            {
                Console.WriteLine($"{submission.Key}");

                foreach (var sub in submission.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {sub.Key} -> {sub.Value}");
                }
            }
        }
    }
}