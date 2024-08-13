using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }
        
        public IReadOnlyCollection<IPlanet> Models => planets.AsReadOnly();

        public void AddItem(IPlanet model)
        {
            planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return planets.FirstOrDefault(p => p.Name == name);
        }

        public bool RemoveItem(string name)
        {
            IPlanet planet = FindByName(name);

            if (planet != null)
            {
                planets.Remove(planet);
                return true;
            }

            return false;
        }
    }
}
