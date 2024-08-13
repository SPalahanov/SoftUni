using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void WeaponConstructor()
            {
                Weapon weapon = new Weapon("Weapon", 10.0, 2);

                Assert.AreEqual("Weapon", weapon.Name);
                Assert.AreEqual(10.0, weapon.Price);
                Assert.AreEqual(2, weapon.DestructionLevel);
                Assert.IsNotNull(weapon);
            }

            [Test]
            public void WeaponPriceThrowException()
            {
                Assert.Throws<ArgumentException>(() => new Weapon("Weapon", -10.0, 2));
            }

            [Test]
            public void WeaponIncreaseDestructionLevel()
            {
                Weapon weapon = new Weapon("Weapon", 10.0, 2);

                weapon.IncreaseDestructionLevel();

                Assert.AreEqual(3, weapon.DestructionLevel);
            }

            [Test]
            public void WeaponIsNuclear()
            {
                Weapon weapon = new Weapon("Weapon", 10.0, 10);

                Assert.AreEqual(true, weapon.IsNuclear);
            }

            [Test]
            public void WeaponIsNotNuclear()
            {
                Weapon weapon = new Weapon("Weapon", 10.0, 1);

                Assert.AreEqual(false, weapon.IsNuclear);
            }

            [Test]
            public void PlanetConstructor()
            {
                Planet planet = new Planet("Planet", 10.0);

                Weapon weapon = new Weapon("Weapon", 2.0, 2);

                Assert.AreEqual("Planet", planet.Name);
                Assert.AreEqual(10.0, planet.Budget);
                Assert.IsNotNull(planet);
                Assert.IsEmpty(planet.Weapons);
            }

            [Test]
            public void PlanetNameThrowException()
            {
                Assert.Throws<ArgumentException>(() => new Planet(null, 10.0));
                Assert.Throws<ArgumentException>(() => new Planet(string.Empty, 10.0));
                Assert.Throws<ArgumentException>(() => new Planet("", 10.0));
            }

            [Test]
            public void PlanetBudgetThrowException()
            {
                Assert.Throws<ArgumentException>(() => new Planet("Planet", -10.0));
            }

            [Test]
            public void TestMilitaryPowerRation()
            {
                Planet planet = new Planet("Planet", 10.0);

                Weapon weapon = new Weapon("Weapon", 2.0, 2);
                Weapon weapon2 = new Weapon("Weapon2", 4.0, 3);
                Weapon weapon3 = new Weapon("Weapon3", 7.0, 8);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                Assert.AreEqual(13, planet.MilitaryPowerRatio);
            }

            [Test]
            public void TestProfit()
            {
                Planet planet = new Planet("Planet", 10.0);

                planet.Profit(5);

                Assert.AreEqual(15, planet.Budget);
            }

            [Test]
            public void TestSpendFunds()
            {
                Planet planet = new Planet("Planet", 10.0);

                planet.SpendFunds(4);

                Assert.AreEqual(6, planet.Budget);
            }

            [Test]
            public void TestSpendFundsThrowException()
            {
                Planet planet = new Planet("Planet", 10.0);

                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(12));
            }

            [Test]
            public void TestPlanetAddWeapon()
            {
                Planet planet = new Planet("Planet", 10.0);

                Weapon weapon = new Weapon("Weapon", 2.0, 2);
                Weapon weapon2 = new Weapon("Weapon2", 4.0, 3);
                
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(planet.Weapons.Count, 2);
            }

            [Test]
            public void PlanetAddWeaponThrowException()
            {
                Planet planet = new Planet("Planet", 10.0);

                Weapon weapon = new Weapon("Weapon", 2.0, 2);
                Weapon weapon2 = new Weapon("Weapon2", 4.0, 3);
                Weapon weapon3 = new Weapon("Weapon", 7.0, 8);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon3));
            }

            [Test]
            public void PlanetRemoveWeapon()
            {
                Planet planet = new Planet("Planet", 10.0);

                Weapon weapon = new Weapon("Weapon", 2.0, 2);
                Weapon weapon2 = new Weapon("Weapon2", 4.0, 3);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                planet.RemoveWeapon("Weapon2");

                Assert.AreEqual(planet.Weapons.Count, 1);
            }

            [Test]
            public void PlanetUpgradeWeaponThrowException()
            {
                Planet planet = new Planet("Planet", 10.0);

                Weapon weapon = new Weapon("Weapon", 2.0, 2);
                Weapon weapon2 = new Weapon("Weapon2", 4.0, 3);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("Weapon3"));
            }

            [Test]
            public void PlanetUpgradeWeapon()
            {
                Planet planet = new Planet("Planet", 10.0);

                Weapon weapon = new Weapon("Weapon", 2.0, 2);
                Weapon weapon2 = new Weapon("Weapon2", 4.0, 3);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                planet.UpgradeWeapon("Weapon");

                Assert.AreEqual(3, weapon.DestructionLevel);
            }

            [Test]
            public void DestructOpponentThrowException()
            {
                Planet planet = new Planet("Planet", 10.0);
                Weapon weapon = new Weapon("Weapon", 2.0, 2);
                planet.AddWeapon(weapon);
                
                Planet opponent = new Planet("Planet2", 17.5);
                Weapon weapon2 = new Weapon("Weapon2", 4.0, 3);
                opponent.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(opponent));
            }

            [Test]
            public void DestructOpponent()
            {
                Planet planet = new Planet("Planet", 10.0);
                Weapon weapon = new Weapon("Weapon", 2.0, 5);
                planet.AddWeapon(weapon);

                Planet opponent = new Planet("Planet2", 17.5);
                Weapon weapon2 = new Weapon("Weapon2", 4.0, 3);
                opponent.AddWeapon(weapon2);

                Assert.AreEqual(planet.DestructOpponent(opponent), $"{opponent.Name} is destructed!");
            }
        }
    }
}
