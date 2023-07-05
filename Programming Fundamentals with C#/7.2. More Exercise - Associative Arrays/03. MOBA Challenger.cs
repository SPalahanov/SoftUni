namespace _03._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> totalPoints = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "Season end")
            {
                if (input.Contains(" -> "))
                {
                    string[] arguments = input.Split(" -> ");

                    string playerName = arguments[0];
                    string position = arguments[1];
                    int skill = int.Parse(arguments[2]);

                    if (!players.ContainsKey(playerName))
                    {
                        players.Add(playerName, new Dictionary<string, int>());
                    }

                    if (!players[playerName].ContainsKey(position))
                    {
                        players[playerName].Add(position, skill);
                    }
                    else
                    {
                        if (players[playerName][position] < skill)
                        {
                            players[playerName][position] = skill;
                        }
                    }

                }

                else if (input.Contains(" vs "))
                {
                    string[] inputParts = input.Split(" vs ");
                    string player1 = inputParts[0];
                    string player2 = inputParts[1];

                    if (players.ContainsKey(player1) && players.ContainsKey(player2))
                    {
                        bool isMatchValid = false;
                        foreach (var position in players[player1].Keys)
                        {
                            if (players[player2].ContainsKey(position))
                            {
                                isMatchValid = true;
                                break;
                            }
                        }

                        if (isMatchValid)
                        {
                            int player1TotalSkill = CalculateTotalSkill(players[player1]);
                            int player2TotalSkill = CalculateTotalSkill(players[player2]);

                            if (player1TotalSkill > player2TotalSkill)
                            {
                                players.Remove(player2);
                            }
                            else if (player2TotalSkill > player1TotalSkill)
                            {
                                players.Remove(player1);
                            }
                        }
                    }
                }
            }

            var sortedPlayers = players
                .OrderByDescending(p => CalculateTotalSkill(p.Value))
                .ThenBy(p => p.Key)
                .ToDictionary(p => p.Key, p => p.Value);

            foreach (var player in sortedPlayers)
            {
                Console.WriteLine($"{player.Key}: {CalculateTotalSkill(player.Value)} skill");

                foreach (var position in player.Value.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }

        static int CalculateTotalSkill(Dictionary<string, int> positions)
        {
            int totalSkill = 0;
            foreach (var skill in positions.Values)
            {
                totalSkill += skill;
            }

            return totalSkill;
        }
    }
}