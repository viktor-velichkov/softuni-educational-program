namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("dyno", 120)]
        public void PartConstructorShouldSetAllDataProperly(string name, decimal price)
        {
            //Arrange
            Part part = new Part(name, price);
            //Assert
            Assert.AreEqual(name, part.Name);
            Assert.AreEqual(price, part.Price);
        }

        [Test]
        [TestCase("Viktor")]
        public void ComputerConstructorShouldSetAllDataProperly(string name)
        {
            //Arrange
            Computer computer = new Computer(name);
            //Assert
            Assert.AreEqual(name, computer.Name);
        }

        [Test]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("")]
        public void ComputerConstructorShouldThrowsAnExceptionIfGivenNameIsNullOrWhiteSpace(string name)
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => new Computer(name));
        }

        [Test]
        [TestCase("Viktor", "GPU", 650)]
        public void AddPartMethodShouldAddPartToTheComputerCollection(
            string computerName,
            string partName,
            decimal partPrice)
        {
            //Arrange
            Computer computer = new Computer(computerName);
            Part part = new Part(partName, partPrice);
            //Assert before Act
            Assert.That(computer.TotalPrice, Is.EqualTo(0));
            //Act
            computer.AddPart(part);
            //Assert
            Assert.AreEqual(computer.GetPart(partName), part);
            Assert.That(computer.TotalPrice, Is.EqualTo(partPrice));
        }

        [Test]
        [TestCase("Viktor", null)]
        public void AddPartMethodShouldThrowsAnExceptionIfGivenPartIsNull(
            string computerName,
            Part part)
        {
            //Arrange
            Computer computer = new Computer(computerName);

            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => computer.AddPart(part));
        }

        [Test]
        [TestCase("Viktor", "GPU", 650)]
        public void RemovePartMethodShouldReturnFalseIfComputerCollectionDoesNotContainGivenPart(
            string computerName,
            string partName,
            decimal partPrice)
        {
            //Arrange
            Computer computer = new Computer(computerName);
            Part part = new Part(partName, partPrice);

            //Assert
            Assert.AreEqual(false, computer.RemovePart(part));
        }

        [Test]
        [TestCase("Viktor", "GPU", 650)]
        public void RemovePartMethodShouldReturnTrueIfComputerCollectionDoesContainGivenPart(
            string computerName,
            string partName,
            decimal partPrice)
        {
            //Arrange
            Computer computer = new Computer(computerName);
            Part part = new Part(partName, partPrice);
            //Act
            computer.AddPart(part);

            //Assert
            Assert.AreEqual(true, computer.RemovePart(part));
        }

        [Test]
        [TestCase("Viktor", new string[4] { "GPU", "Mother board", "CPU", "Memory" }, new int[4] { 650, 350, 720, 80})]
        public void PartsPropertyShouldReturnAllThePartsInTheComputerCollection(
            string computerName,
            string[] partNames,
            int[] partPrices)
        {
            //Arrange
            Computer computer = new Computer(computerName);
            for (int i = 0; i < partNames.Length; i++)
            {
                computer.AddPart(new Part(partNames[i], (decimal)partPrices[i]));
            }

            //Act
            var parts = computer.Parts;

            //Assert
            int counter = 0;
            foreach (var part in parts)
            {
                Assert.AreEqual(part.Name, partNames[counter]);
                Assert.AreEqual(part.Price, partPrices[counter]);
                counter++;
            }                        Assert.AreEqual(parts.Select(x => x.Price).Sum(),computer.TotalPrice);
            
        }
    }
}