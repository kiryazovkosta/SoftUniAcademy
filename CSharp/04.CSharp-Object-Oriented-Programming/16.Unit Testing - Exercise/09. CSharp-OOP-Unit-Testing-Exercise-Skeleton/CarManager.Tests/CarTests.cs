namespace Tests
{
    using NUnit.Framework;

    using CarManager;
    using System;

    public class CarTests
    {
        private Car car;
        
        [SetUp]
        public void SetUp()
        {
            car = new Car("Toyota", "Corolla", 2.0, 50.0);
        }

        [Test]
        public void CtorCreateValidCar()
        {
            //Car car = new Car("Toyota", "Corolla", 2.0, 50.0);
            Assert.IsNotNull(car);
            Assert.AreEqual("Toyota", car.Make);
            Assert.AreEqual("Corolla", car.Model);
            Assert.That(2.0, Is.EqualTo(car.FuelConsumption));
            Assert.That(50.0, Is.EqualTo(car.FuelCapacity));
            Assert.That(0, Is.EqualTo(car.FuelAmount));
        }

        [Test]
        [TestCase("", "Corolla", 2.0, 50.0, "Make cannot be null or empty!")]
        [TestCase(null, "Corolla", 2.0, 50.0, "Make cannot be null or empty!")]
        [TestCase("Toyota", "", 2.0, 50.0, "Model cannot be null or empty!")]
        [TestCase("Toyota", null, 2.0, 50.0, "Model cannot be null or empty!")]
        [TestCase("Toyota", "Corolla", 0, 50.0, "Fuel consumption cannot be zero or negative!")]
        [TestCase("Toyota", "Corolla", -2, 50.0, "Fuel consumption cannot be zero or negative!")]
        [TestCase("Toyota", "Corolla", 10.0, 0.0, "Fuel capacity cannot be zero or negative!")]
        [TestCase("Toyota", "Corolla", 2, -0.5, "Fuel capacity cannot be zero or negative!")]
        public void CtorThrowsExceptionOnInvalidInput(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity,
            string message)
        {
            var exception = Assert.Throws<ArgumentException>( () => new Car(make, model, fuelConsumption, fuelCapacity));
            Assert.That(message, Contains.Substring(exception.Message));
        }

        [Test]
        [TestCase(0.0)]
        [TestCase(-10.2)]
        public void RefuelThrowsExceptionWhenFuelAmountCannotBeZeroOrNegative(double fuelToRefuel)
        {
            var exception = Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
            Assert.That("Fuel amount cannot be zero or negative!", Contains.Substring(exception.Message));
        }

        [Test]
        [TestCase(20.0, 20.0)]
        [TestCase(50.0, 50.0)]
        [TestCase(80.0, 50.0)]
        public void RefuelAddFuelToRefuelToCarFuelAmount(double fuelToRefuel, double expectedFuel)
        {
            car.Refuel(fuelToRefuel);
            Assert.AreEqual(expectedFuel, car.FuelAmount);
        }

        [TestCase]
        public void DriveThrowsExceptionWhenFuelNeededIsBiggerThanFuelAmount()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => car.Drive(100));
            Assert.That(exception.Message, Contains.Substring("You don't have enough fuel to drive!"));
        }

        [Test]
        public void DriveShouldReduseFuelAmount()
        {
            car.Refuel(1);
            car.Drive(30);
            Assert.AreEqual(0.4, car.FuelAmount);
        }
    }
}