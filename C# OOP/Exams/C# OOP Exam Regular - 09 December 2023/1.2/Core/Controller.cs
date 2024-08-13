using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private IRepository<IDiver> divers;
        private IRepository<IFish> fishes;

        public Controller()
        {
            divers = new DiverRepository();
            fishes = new FishRepository();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType != "FreeDiver" && diverType != "ScubaDiver")
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            IDiver diver = divers.Models.FirstOrDefault(d => d.Name == diverName);

            if (diver != null)
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, "DiverRepository");
            }

            if (diverType == "FreeDiver")
            {
                diver = new FreeDiver(diverName);
            }
            else if (diverType == "ScubaDiver")
            {
                diver = new ScubaDiver(diverName);
            }

            divers.AddModel(diver);

            return string.Format(OutputMessages.DiverRegistered, diverName, "DiverRepository");
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType != "DeepSeaFish" && fishType != "PredatoryFish" && fishType != "ReefFish")
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            IFish fish = fishes.Models.FirstOrDefault(f => f.Name == fishName);

            if (fish != null)
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, "FishRepository");
            }

            if (fishType == "DeepSeaFish")
            {
                fish = new DeepSeaFish(fishName, points);
            }
            else if (fishType == "PredatoryFish")
            {
                fish = new PredatoryFish(fishName, points);
            }
            else if (fishType == "ReefFish")
            {
                fish = new ReefFish(fishName, points);
            }

            fishes.AddModel(fish);

            return string.Format(OutputMessages.FishCreated, fishName);
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver diver = divers.Models.FirstOrDefault(d => d.Name == diverName);

            if (diver == null)
            {
                return string.Format(OutputMessages.DiverNotFound,"DiverRepository", diverName);
            }

            IFish fish = fishes.Models.FirstOrDefault(d => d.Name == fishName);

            if (fish == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            if (diver.HasHealthIssues == true)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);

                if (diver.OxygenLevel == 0)
                {
                    diver.UpdateHealthStatus();
                }

                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (diver.OxygenLevel == fish.TimeToCatch)
            {
                if (isLucky == true)
                {
                    diver.Hit(fish);

                    if (diver.OxygenLevel == 0)
                    {
                        diver.UpdateHealthStatus();
                    }

                    return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points,fishName);
                }
                else if (isLucky == false)
                {
                    diver.Miss(fish.TimeToCatch);

                    if (diver.OxygenLevel == 0)
                    {
                        diver.UpdateHealthStatus();
                    }

                    return string.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }

            diver.Hit(fish);

            if (diver.OxygenLevel == 0)
            {
                diver.UpdateHealthStatus();
            }

            return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
        }

        public string HealthRecovery()
        {
            int recoveredDiverCount = 0;

            foreach (var diver in divers.Models.Where(d => d.HasHealthIssues == true))
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();

                recoveredDiverCount++;
            }

            return string.Format(OutputMessages.DiversRecovered, recoveredDiverCount);
        }

        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();
            
            IDiver diver = divers.GetModel(diverName);

            sb.AppendLine(diver.ToString().TrimEnd());

            sb.AppendLine("Catch Report:");

            foreach (var cachedFish in diver.Catch)
            {
                foreach (var fish in fishes.Models.Where(f => f.Name == cachedFish))
                {
                    sb.AppendLine(fish.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");
            
            foreach (var diver in divers.Models
                         .Where(d =>d.HasHealthIssues == false)
                         .OrderByDescending(d => d.CompetitionPoints)
                         .ThenByDescending(d => d.Catch.Count)
                         .ThenBy(d => d.Name))
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
