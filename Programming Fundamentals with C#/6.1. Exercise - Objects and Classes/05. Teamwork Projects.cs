namespace _05._Teamwork_Projects
{
    class Team
    {
        public Team(string name, string creator)
        {
            Name = name;
            Creator = creator;
            Member = new List<string>();
        }

        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Member { get; set; }

        public override string ToString()
        {
            return $"{Name}\n" +
                   $"- {Creator}\n" +
                   $"{GetMembersString()}";
        }

        private string GetMembersString()
        {
            Member = Member
                .OrderBy(name => name)
                .ToList();

            string result = "";
            for (int i = 0; i < Member.Count - 1; i++)
            {
                result += $"-- {Member[i]}\n";
            }

            result += $"-- {Member[Member.Count - 1]}";
            return result;
        }
    }
    
    
    
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfTeam = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < countOfTeam; i++)
            {
                string[] inputTeam = Console.ReadLine().Split("-");

                string creator = inputTeam[0];
                string name = inputTeam[1];
                
                Team team = new Team(name, creator);

                Team sameTeam = teams.Find(x => x.Name == name);
                Team sameCreator = teams.Find(x => x.Creator == creator);

                if (sameCreator != null)
                {
                    Console.WriteLine($"{team.Creator} cannot create another team!");
                    continue;
                }

                if (sameTeam != null)
                {
                    Console.WriteLine($"Team {team.Name} was already created!");
                    continue;
                }

                teams.Add(team);
                Console.WriteLine($"Team {team.Name} has been created by {team.Creator}!");
            }

            string command;

            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] arguments = command.Split("->");

                string joinerName = arguments[0];
                string teamName = arguments[1];

                if (!teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (teams.Any(team => team.Creator == joinerName) ||
                    teams.Any(team => team.Member.Contains(joinerName)))
                {
                    Console.WriteLine($"Member {joinerName} cannot join team {teamName}!");
                    continue;
                }

                teams.Find(team => team.Name == teamName).Member.Add(joinerName);
            }


            List<Team> leftTeams = teams.Where(team => team.Member.Count > 0).ToList();
            List<Team> disbandTeams = teams.Where(team => team.Member.Count <= 0).ToList();

            List<Team> orderedTeams = leftTeams
                .OrderByDescending(team => team.Member.Count)
                .ThenBy(team => team.Name)
                .ToList();

            orderedTeams.ForEach(team => Console.WriteLine(team));

            Console.WriteLine("Teams to disband:");
            orderedTeams = disbandTeams.OrderBy(x => x.Name).ToList();
            orderedTeams.ForEach(team => Console.WriteLine(team.Name));
        }
    }
}