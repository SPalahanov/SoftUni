using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }
        
        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = planets.FindByName(name);

            if (planet != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            planet = new Planet(name, budget);

            planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != "AnonymousImpactUnit" && unitTypeName != "SpaceForces" && unitTypeName != "StormTroopers")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit unit = null;
            double amount = 0;

            if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
                amount = unit.Cost;
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
                amount = unit.Cost;
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
                amount = unit.Cost;
            }

            planet.Spend(amount);

            planet.AddUnit(unit);
            
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (weaponTypeName != "BioChemicalWeapon" && weaponTypeName != "SpaceMissiles" && weaponTypeName != "NuclearWeapon")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            IWeapon weapon = null;
            double amount = 0;

            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
                amount = weapon.Price;
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
                amount = weapon.Price;
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
                amount = weapon.Price;
            }

            planet.Spend(amount);

            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (!planet.Army.Any())
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }

            IMilitaryUnit unit;

            planet.Spend(1.25);
            planet.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower
                && firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")
                && secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);

                secondPlanet.Spend(secondPlanet.Budget / 2);

                return string.Format(OutputMessages.NoWinner);
            }

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower
                && firstPlanet.Weapons.Any(w => w.GetType().Name != "NuclearWeapon")
                && secondPlanet.Weapons.Any(w => w.GetType().Name != "NuclearWeapon"))
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);

                secondPlanet.Spend(secondPlanet.Budget / 2);

                return string.Format(OutputMessages.NoWinner);
            }

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower
                && firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Army.Sum(u => u.Cost) + secondPlanet.Weapons.Sum(u => u.Price));
                planets.RemoveItem(secondPlanet.Name);

                return string.Format(OutputMessages.WinnigTheWar, firstPlanet.Name, secondPlanet.Name);
            }

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower 
                && secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                secondPlanet.Spend(secondPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Army.Sum(u => u.Cost) + firstPlanet.Weapons.Sum(u => u.Price));
                planets.RemoveItem(firstPlanet.Name);

                return string.Format(OutputMessages.WinnigTheWar, secondPlanet.Name, firstPlanet.Name);
            }

            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Army.Sum(u => u.Cost) + secondPlanet.Weapons.Sum(u => u.Price));
                planets.RemoveItem(secondPlanet.Name);

                return string.Format(OutputMessages.WinnigTheWar, firstPlanet.Name, secondPlanet.Name);
            }
            else
            {
                secondPlanet.Spend(secondPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Army.Sum(u => u.Cost) + firstPlanet.Weapons.Sum(u => u.Price));
                planets.RemoveItem(firstPlanet.Name);

                return string.Format(OutputMessages.WinnigTheWar, secondPlanet.Name, firstPlanet.Name);
            }
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models.OrderByDescending(p =>p.MilitaryPower).ThenBy(p =>p.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
