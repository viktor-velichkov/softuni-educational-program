using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Hundai","i30",6,40)]
        public void ConstructorShouldSetAllThePropertiesWhenTheyAreValid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange
            Car car = new Car(make: make, model: model, fuelConsumption: fuelConsumption, fuelCapacity: fuelCapacity);
            //Assert
            Assert.AreEqual(car.Make,make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
            Assert.AreEqual(car.FuelAmount,0);
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ConstructorShouldThrowExceptionIfGivenMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "model", 10, 40));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ConstructorShouldThrowExceptionIfGivenModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", model, 10, 40));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void ConstructorShouldThrowExceptionIfGivenFuelConsumptionValueIsZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", fuelConsumption, 40));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void ConstructorShouldThrowExceptionIfGivenFuelCapacityValueIsZeroOrNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", 10, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void RefuelMethodShouldThrowExceptionIfGivenFuelAmountIsZeroOrNegative(double fuelToRefuel)
        {
            //Arrange
            Car car = new Car("make", "model", 6, 40);
            //Act-Assert
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        [TestCase(5,10)]
        [TestCase(10,40)]
        public void RefuelMethodShouldIncreaseFuelAmountIfGivenFuelToRefuelIsNotZeroOrNegativeAndItIsNotMoreThanTheFreeSpaceInTheTank(
                double fuelToRefuel,
                double fuelCapacity)
        {
            //Arrange
            Car car = new Car("make", "model", 6, fuelCapacity);
            //Act
            car.Refuel(fuelToRefuel);
            //Assert
            Assert.That(car.FuelAmount, Is.EqualTo(fuelToRefuel));
        }

        [Test]
        [TestCase(10, 5)]
        [TestCase(40, 10)]
        public void RefuelMethodShouldIncreaseFuelAmountToTheFuelCapacityIfGivenFuelToRefuelIsMoreThanTheFreeSpaceInTheTank(
                double fuelToRefuel,
                double fuelCapacity)
        {
            //Arrange
            Car car = new Car("make", "model", 6, fuelCapacity);
            //Act
            car.Refuel(fuelToRefuel);
            //Assert
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        [TestCase(6,5,100)]
        [TestCase(7, 34, 500)]
        public void DriveMethodShouldThrowExceptionIfThereIsNotEnoughFuelInTheCarToDriveTheGivenDistance(double fuelConsumption,
                                                                                                         double fuelToRefuel,
                                                                                                         double distance)
        {
            //Arrange
            Car car = new Car("Hyundai", "i30", fuelConsumption, 40);
            car.Refuel(fuelToRefuel);
            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        [Test]
        [TestCase(6, 30, 360)]
        [TestCase(7, 40, 500)]
        public void DriveMethodShouldDecreaseFuelAmountIfThereIsEnoughFuelInTheCarToDriveTheGivenDistance(double fuelConsumption,
                                                                                                          double fuelToRefuel,
                                                                                                          double distance)
        {
            //Arrange
            Car car = new Car("Hyundai", "i30", fuelConsumption, 100);
            car.Refuel(fuelToRefuel);
            //Act
            double expectedFuelAmount = car.FuelAmount - (distance / 100 * car.FuelConsumption);
            car.Drive(distance);
            
            //Assert
            Assert.AreEqual(car.FuelAmount, expectedFuelAmount);
        }
    }
}