namespace INStock.Tests
{
    using NUnit.Framework;
    using System;

    public class ProductTests
    {
        [Test]
        [TestCase("maratonki",50,10)]
        public void ConstructorShouldSetAllTheDataProperly(string label, decimal price, int quantity)
        {
            //Arrange
            Product product = new Product(label, price, quantity);
            //Assert
            Assert.That(label, Is.EqualTo(product.Label));
            Assert.That(price, Is.EqualTo(product.Price));
            Assert.That(quantity, Is.EqualTo(product.Quantity));
        }
        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void ConstructorShouldThrowExceptionIfLabelIsNullOrEmpty(string label)
        {
            //Act-Assert
            Assert.Throws<ArgumentException>(() => new Product(label, 100m, 10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-50)]
        public void ConstructorShouldThrowExceptionIfPriceIsZeroOrNegative(decimal price)
        {
            //Act-Assert
            Assert.Throws<ArgumentException>(() => new Product("chorap", price, 10));
        }

        [Test]
        [TestCase(-50)]
        public void ConstructorShouldThrowExceptionIfQuantityIsNegative(int quantity)
        {
            //Act-Assert
            Assert.Throws<ArgumentException>(() => new Product("chorap", 100m, quantity));
        }
    }
}