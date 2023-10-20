using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {

        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            players = new List<Player>();
        }

        public string Name { get; private set; }
        public int OpenPositions { get; private set; }
        public char Group { get; private set; }

        public IReadOnlyCollection<Player> Players => players;

        public string AddPlayer(Player player)
        {
            if (player.Position == null || player.Name == null)
            {
                return "Invalid player's information.";
            }

            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                players.Add(player);

                OpenPositions--;

                return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
            }
        }

        public int Count => players.Count;

        public bool RemovePlayer(string name)
        {
            if (players.Exists(p => p.Name == name))
            {
                players.Remove(players.FirstOrDefault(p => p.Name == name));
                OpenPositions++;
                return true;
            }

            return false;
        }

        public Player RetirePlayer(string name)
        {
            Player playerToRetire = Players.FirstOrDefault(x => x.Name == name);
            if (playerToRetire == null)
            {
                return null;
            }
            playerToRetire.Retired = true;
            return playerToRetire;
        }


        public List<Player> AwardPlayers(int games)
        {
            return players.FindAll(g => g.Games >= games);
        }

        public int RemovePlayerByPosition(string position)
        {
            if (players.Exists(p => p.Position == position))
            {
                int removedPlayersCount = players.RemoveAll(p => p.Position == position);

                OpenPositions += removedPlayersCount;

                return removedPlayersCount;
            }
            else
            {
                return 0;
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach (var player in players.Where(p => p.Retired == false))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
