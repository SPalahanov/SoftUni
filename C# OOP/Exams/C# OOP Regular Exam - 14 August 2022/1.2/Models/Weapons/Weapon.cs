using System;
using System.Collections.Generic;
using System.Text;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;
        private double price;

        protected Weapon(int destructionLevel, double price)
        {
            DestructionLevel = destructionLevel;
            Price = price;
        }

        public double Price { get; private set; }

        public int DestructionLevel
        {
            get => destructionLevel;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                
                if (value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }
                
                destructionLevel = value;
            }
        }
    }
}
