namespace _02._Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contests = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> totalPoints = new Dictionary<string, int>();

            string input;

            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] arguments = input.Split(" -> ");

                string userName = arguments[0];
                string contestName = arguments[1];
                int points = int.Parse(arguments[2]);

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, new Dictionary<string, int>());
                }

                if (!contests[contestName].ContainsKey(userName))
                {
                    contests[contestName].Add(userName, points);
                }
                else
                {
                    contests[contestName][userName] = Math.Max(contests[contestName][userName], points);
                }

                if (!totalPoints.ContainsKey(userName))
                {
                    totalPoints.Add(userName, 0);
                }
                totalPoints[userName] += points;
            }
            
            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                int position = 1;
                foreach (var kvp in contest.Value.OrderByDescending(x => x.Value).ThenBy(p => p.Key))
                {
                    Console.WriteLine($"{position}. {kvp.Key} <::> {kvp.Value}");
                    position++;
                }
            }

            Console.WriteLine("Individual standings:");

            int userPosition = 1;

            foreach (var user in totalPoints.OrderByDescending(u => u.Value).ThenBy(u => u.Key))
            {
                Console.WriteLine($"{userPosition}. {user.Key} -> {user.Value}");
                userPosition++;
            }
        }
    }
}