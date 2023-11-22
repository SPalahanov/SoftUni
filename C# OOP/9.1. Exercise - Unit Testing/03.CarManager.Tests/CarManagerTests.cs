namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("Toyota", "Corolla", 6.0, 60.0);
        }

        [Test]
        public void CarConstructorShouldWorkCorrectly()
        {
            string expectedMake = "Toyota";
            string expectedModel = "Corolla";
            int expectedFuelConsumption = 6;
            int expectedFuelCapacity = 60;

            car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            Assert.NotNull(car);
            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void CarShouldBeCreatedWithZeroFuelAmount()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CarConstructorShouldThrowExceptionIfMakeIsNullOrEmpty(string make)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car(make, "Corolla",6, 60));

            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CarConstructorShouldThrowExceptionIfModelIsNullOrEmpty(string model)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("Toyota", model, 6, 60));

            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [TestCase(-15)]
        [TestCase(-1)]
        [TestCase(0)]
        public void CarConstructorShouldThrowExceptionIfFuelConsumptionIsNotPositive(double fuelConsumption)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("Toyota", "Corolla", fuelConsumption, 60));

            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        [TestCase(-15)]
        [TestCase(-1)]
        [TestCase(0)]
        public void CarConstructorShouldThrowExceptionIfFuelCapacityIsNotPositive(double fuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("Toyota", "Corolla", 6, fuelCapacity));

            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarShouldThrowExceptionIfFuelAmountIsNegative()
        {
            Assert.Throws<InvalidOperationException>(()
                => car.Drive(11), "Fuel amount cannot be negative!");
        }

        [Test]
        public void CarRefuelShouldIncreaseFuelAmountCorrectly()
        {
            double expectedResult = 35;

            car.Refuel(35);

            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-15)]
        [TestCase(-1)]
        [TestCase(0)]
        public void CarRefuelShouldThrowExceptionIfFuelIsNotPositive(double fuelToRefuel)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car.Refuel(fuelToRefuel));

            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarFuelAmountShouldNotBeMoreThanFuelCapacity()
        {
            int expectedResult = 60;

            car.Refuel(70);

            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        [Test]
        public void CarDriveShouldDecreaseFuelAmountCorrectly()
        {
            double expectedResult = 5;

            car.Refuel(35);
            car.Drive(500);

            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CarDriveShouldThrowExceptionIfFuelNeededIsMoreThanFuelAmount()
        {
            car.Refuel(24);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => car.Drive(500));

            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }
    }
}