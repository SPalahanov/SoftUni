using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private double competitionPoints;
        private int oxygenLevel;
        private List<string> catchList;

        protected Diver(string name, int oxygenLevel)
        {
            Name = name;
            CompetitionPoints = 0;
            OxygenLevel = oxygenLevel;
            HasHealthIssues = false;
            catchList = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.DiversNameNull);
                }

                name = value;
            }
    }

        public int OxygenLevel
        {
            get => oxygenLevel;
            protected set
            {
                oxygenLevel = Math.Max(0, value);
            }
        }

        public IReadOnlyCollection<string> Catch => catchList.AsReadOnly();

        public double CompetitionPoints
        {
            get => Math.Round(competitionPoints, 1);
            private set
            {
                competitionPoints = value;
            }
        }

        public bool HasHealthIssues { get; private set; }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            catchList.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            if (HasHealthIssues == false)
            {
                HasHealthIssues = true;
            }
            else
            {
                HasHealthIssues = false;
            }
        }

        public override string ToString()
        {
            return
               $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {catchList.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
