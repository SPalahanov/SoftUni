using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> units;

        public UnitRepository()
        {
            units = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => units.AsReadOnly();

        public void AddItem(IMilitaryUnit model)
        {
            units.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return units.FirstOrDefault(unit => string.Equals(unit.GetType().Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public bool RemoveItem(string name)
        {
            IMilitaryUnit unit = FindByName(name);

            if (unit != null)
            {
                units.Remove(unit);
                return true;
            }

            return false;
        }
    }
}
