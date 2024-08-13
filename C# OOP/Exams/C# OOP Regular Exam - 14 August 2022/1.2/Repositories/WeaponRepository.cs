using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => weapons.AsReadOnly();

        public void AddItem(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return weapons.FirstOrDefault(weapon => string.Equals(weapon.GetType().Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public bool RemoveItem(string name)
        {
            IWeapon weapon = FindByName(name);

            if (weapon != null)
            {
                weapons.Remove(weapon);
                return true;
            }

            return false;
        }
    }
}
