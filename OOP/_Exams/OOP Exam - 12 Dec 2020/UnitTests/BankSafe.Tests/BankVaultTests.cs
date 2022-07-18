using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault; 
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
        }

        [Test]
        [TestCase(new string[12] { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4", "C1", "C2", "C3", "C4" }, null)]
        public void ConstructorShouldCreateANewInstanceOfADinctionary(string[] keys, Item value)
        {
            //Arrange
            BankVault bankVault = new BankVault();
            //Act
            var bankVaultCellsKeys = bankVault.VaultCells.Keys.OrderBy(x => x).ToArray();
            var bankVaultCellsValues = bankVault.VaultCells.Values.ToArray();
            //Assert
            Assert.That(bankVault.VaultCells, Is.Not.Null);
            for (int i = 0; i < keys.Length; i++)
            {
                Assert.AreEqual(keys[i], bankVaultCellsKeys[i]);
                Assert.AreEqual(value, bankVaultCellsValues[i]);
            }

        }

        [Test]
        [TestCase("A5", "Viktor", "123")]
        public void AddItemMethodShouldThrowAnExceptionIfGivenCellDoesNotExist(string cell, string owner, string itemId)
        {
            //Arrange
            Item item = new Item(owner, itemId);
            //Act-Assert
            Assert.Throws<ArgumentException>(() => bankVault.AddItem(cell, item));
        }

        [Test]
        [TestCase("A1", "Viktor", "123", "Pesho", "546")]
        public void AddItemMethodShouldThrowAnExceptionIfGivenCellAlreadyHasAnItemInIt(
                    string cell,
                    string firstOwner,
                    string firstItemId,
                    string secondOwner,
                    string secondItemId)
        {
            //Arrange
            Item firstItem = new Item(firstOwner, firstItemId);
            Item secondItem = new Item(secondOwner, secondItemId);
            bankVault.AddItem(cell, firstItem);
            //Act-Assert
            Assert.Throws<ArgumentException>(() => bankVault.AddItem(cell, secondItem));
        }

        [Test]
        [TestCase("A1", "A2", "Viktor", "123")]
        public void AddItemMethodShouldThrowAnExceptionIfGivenItemIsAlreadyInACell(
                    string firstCell,
                    string secondCell,
                    string owner,
                    string itemId)
        {
            //Arrange
            Item item = new Item(owner, itemId);
            bankVault.AddItem(firstCell, item);
            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem(secondCell, item));
        }

        [Test]
        [TestCase("A1", "Viktor", "123")]
        public void AddItemMethodShouldAddTheGivenItemToTheGivenCell(
                    string cell,
                    string owner,
                    string itemId)
        {
            //Arrange            
            Item item = new Item(owner, itemId);
            string actualResult = bankVault.AddItem(cell, item);
            string expectedResult = $"Item:{itemId} saved successfully!";
            Item itemInTheCell = bankVault.VaultCells[cell];
            //Act-Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(bankVault.VaultCells.Values.Where(x => x != null).Count(), 1);
            Assert.AreEqual(itemInTheCell.Owner, owner);
            Assert.AreEqual(itemInTheCell.ItemId, itemId);
            Assert.AreEqual(itemInTheCell, item);
        }

        [Test]
        [TestCase("A5", "Viktor", "123")]
        public void RemoveItemMethodShouldThrowAnExceptionIfCellDoesNotExist(
                    string cell,
                    string owner,
                    string itemId)
        {
            //Arrange            
            Item item = new Item(owner, itemId);
            
            //Act-Assert
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem(cell, item));
        }

        [Test]
        [TestCase("A1", "Viktor", "123", "Pesho","456")]
        public void RemoveItemMethodShouldThrowAnExceptionIfTheItemInTheGivenCellIsDifferentFromTheGivenOne(
                    string cell,
                    string firstOwner,
                    string firstItemId,
                    string secondOwner,
                    string secondItemId)
        {
            //Arrange            
            Item firstItem = new Item(firstOwner, firstItemId);
            Item secondItem = new Item(secondOwner, secondItemId);
            bankVault.AddItem(cell, firstItem);

            //Act-Assert
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem(cell, secondItem));
        }

        [Test]
        [TestCase("A1", "Viktor", "123")]
        public void RemoveItemMethodShouldRemoveGivenItemFromTheGivenCell(
                    string cell,
                    string owner,
                    string itemId)
        {
            //Arrange            
            Item item = new Item(owner, itemId);
            bankVault.AddItem(cell, item);
            string actualResult = bankVault.RemoveItem(cell, item);
            string expectedResult = $"Remove item:{itemId} successfully!";
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(bankVault.VaultCells[cell], null);
        }


    }
}