using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1, 16, 16)]
        public void ConstructorShouldBeInitializedWithArrayOfMaximum16Integers(int rangeStart, int rangeEnd, int result)
        {
            //Arrange
            int[] data = Enumerable.Range(rangeStart, rangeEnd).ToArray();
            Database dataBase = new Database(data);

            //Act
            int expectedDatabaseCount = result;
            int actualDatabaseCount = dataBase.Count;
            //Assert
            Assert.That(actualDatabaseCount, Is.EqualTo(expectedDatabaseCount), "Database constructor is not working properly!");
        }

        [Test]
        [TestCase(1, 17)]
        public void ConstructorShouldThrowExceptionIfBeingInitializedWithAnArrayOfMoreThan16Integers(int rangeStart, int rangeEnd)
        {
            //Arrange
            int[] data = Enumerable.Range(rangeStart, rangeEnd).ToArray();

            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => new Database(data), "Object Database initialized succesfully!");
        }

        [Test]
        [TestCase(1, 10,11)]
        public void AddMethodShouldAddElementAtTheEndOfTheDatabaseArray(int rangeStart, int rangeEnd, int result)
        {
            //Arrange
            int[] data = Enumerable.Range(rangeStart, rangeEnd).ToArray();
            Database dataBase = new Database(data);

            //Act
            dataBase.Add(11);
            int actualLastElement = dataBase.Fetch().Last();

            //Assert
            Assert.AreEqual(actualLastElement, result);
        }

        [Test]
        [TestCase(1,16,17)]
        public void AddMethodShouldThrowExceptionIfDatabaseCountIs16(int rangeStart, int rangeEnd, int intToAdd)
        {
            //Arrange
            int[] data = Enumerable.Range(rangeStart, rangeEnd).ToArray();
            Database dataBase = new Database(data);

            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => dataBase.Add(intToAdd), "Number added successfully!");
        }

        [Test]
        [TestCase(1,16,15)]
        public void RemoveMethodShouldRemoveTheLastElementOfTheDatabaseArray(int rangeStart, int rangeEnd, int result)
        {
            //Arrange
            int[] data = Enumerable.Range(rangeStart, rangeEnd).ToArray();
            Database dataBase = new Database(data);
            //Act
            dataBase.Remove();
            int[] actualDatabaseArray = dataBase.Fetch();
            int expectedElement = result;
            int axtualElement = actualDatabaseArray.Last();
            //Assert
            Assert.That(axtualElement, Is.EqualTo(expectedElement), "Remove method removed more that one element or did not remove any!");
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            //Arrange
            Database dataBase = new Database();

            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => dataBase.Remove());
        }

        [Test]
        [TestCase(1,9)]
        public void FetchMethodShouldReturnTheFullArrayOfTheDatabase(int rangeStart, int rangeEnd)
        {
            //Arrange
            int[] data = Enumerable.Range(rangeStart, rangeEnd).ToArray();
            Database dataBase = new Database(data);
            //Act
            int[] dataBaseArray = dataBase.Fetch();
            int[] expectedArray = data;
            //Assert
            CollectionAssert.AreEqual(expectedArray, dataBaseArray);
        }

    }
}