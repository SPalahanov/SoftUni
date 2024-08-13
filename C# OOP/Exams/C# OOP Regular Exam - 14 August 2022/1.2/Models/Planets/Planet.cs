using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        
        private List<IMilitaryUnit> units;
        private List<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;

            MilitaryPower = militaryPower;
            
            units = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }

        public double MilitaryPower
        {
            get { return CalculateMilitaryPower(); } private set { }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => units.AsReadOnly();

        public IReadOnlyCollection<IWeapon> Weapons => weapons.AsReadOnly();

        public void AddUnit(IMilitaryUnit unit)
        {
            units.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public void TrainArmy()
        {
            foreach (var militaryUnit in units)
            {
                militaryUnit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new ArgumentException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");

            string result = string.Empty;

            if (units.Any() == true)
            {
                result = string.Join(", ", units.Select(w => w.GetType().Name));
            }
            else
            {
                result = "No units";
            }

            sb.AppendLine($"--Forces: {result}");

            if (weapons.Any() == true)
            {
                result = string.Join(", ", weapons.Select(w =>w.GetType().Name));
            }
            else
            {
                result = "No weapons";
            }

            sb.AppendLine($"--Combat equipment: {result}");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        private double CalculateMilitaryPower()
        {
            double totalAmount = units.Sum(unit => unit.EnduranceLevel) + weapons.Sum(weapon => weapon.DestructionLevel);

            if (units.Any(unit => unit is AnonymousImpactUnit))
            {
                totalAmount *= 1.3;
            }

            if (weapons.Any(weapon => weapon is NuclearWeapon))
            {
                totalAmount *= 1.45;
            }

            return Math.Round(totalAmount, 3);
        }
    }
}
