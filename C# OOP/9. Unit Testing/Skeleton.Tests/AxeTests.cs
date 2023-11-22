using System;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(10, 20);
        }
        
        [Test]
        public void AxeShouldBeCreatedCorrectly()
        {
            int expectedAttack = 10;
            int expectedDurability = 20;

            Assert.AreEqual(expectedAttack, axe.AttackPoints);
            Assert.AreEqual(expectedDurability, axe.DurabilityPoints);
        }
        
        [Test]
        public void AxeLoosesDurabilityAfterEachAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void AttackWithBrokenAxe()
        {
            axe = new Axe(10, 0);
            dummy = new Dummy(10, 10);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => axe.Attack(dummy));

            Assert.AreEqual("Axe is broken.", exception.Message);
        }
    }

}