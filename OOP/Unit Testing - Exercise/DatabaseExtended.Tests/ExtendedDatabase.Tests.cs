using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ExtendedDatabaseTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase(15, 123456789, "Viktor", 15)]
        public void ConstructorShouldBeInitializedWithArrayOfMaximum16ElementsOfTypePerson(
                int peopleCount,
                long id,
                string name,
                int expectedDatabaseCount)
        {
            //Arrange
            ExtendedDatabase dataBase = CreateExtendedDatabase(peopleCount, id, name);

            //Act
            int expectedResult = expectedDatabaseCount;
            int actualDatabaseCount = dataBase.Count;

            //Assert
            Assert.That(actualDatabaseCount, Is.EqualTo(expectedResult),
                        "Constructor does not work properly! The count of the elements in the Database is not as expected!");
        }

        [Test]
        [TestCase(17, 123456789, "Viktor")]
        public void ConstructorShouldThrowExceptionIfBeingInitializedWithArrayOfMoreThan16ElementsOfTypePerson(
                int peopleCount,
                long id,
                string name)
        {
            //Arrange
            Person[] people = CreatePersonArray(peopleCount, id, name);

            //Act-Assert
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(people),
                "Constructor initialized succesfully!");
        }

        [Test]
        [TestCase(15, 123456789, "Viktor", 16)]
        public void AddMethodShouldAddElementAtTheEndOfTheDatabaseArray(
                int peopleCount,
                long id,
                string name,
                int expectedDatabaseCount)
        {
            //Arrange
            ExtendedDatabase dataBase = CreateExtendedDatabase(peopleCount, id, name);

            //Act
            Person simeon = new Person(id + peopleCount + 1, name + name);
            dataBase.Add(simeon);
            int expectedCount = expectedDatabaseCount;
            int actualCount = dataBase.Count;

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount),
                        "Add method does not work properly! The count of the elements in the Database is not as expected!");
            Assert.That(dataBase.FindById(id + peopleCount + 1), Is.EqualTo(simeon), "Person was not added to the database!");
        }

        [Test]
        [TestCase(16, 123456789, "Viktor")]
        public void AddMethodShouldThrowExceptionIfDatabaseCountIs16(
                int peopleCount,
                long id,
                string name)
        {
            //Arrange
            ExtendedDatabase dataBase = CreateExtendedDatabase(peopleCount, id, name);
            Person simeon = new Person(id + peopleCount + 1, name + name);
            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => dataBase.Add(simeon),
                                "Add method added element to the collection, although it was full!");
        }

        [Test]
        [TestCase(10, 123456789, "Viktor")]
        public void AddMethodShouldThrowExceptionIfPersonWithTheSameUsernameIsAlreadyInTheCollection(
                int peopleCount,
                long id,
                string name)
        {
            //Arrange
            ExtendedDatabase dataBase = CreateExtendedDatabase(peopleCount, id, name);
            Person newPerson = new Person(id - 1, name + "a");

            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => dataBase.Add(newPerson),
                                    "There are more than one people with same usernames!");
        }


        [Test]
        [TestCase(10, 123456789, "Viktor")]
        public void AddMethodShouldThrowExceptionIfPersonWithTheSameIdIsAlreadyInTheCollection(
                int peopleCount,
                long id,
                string name)
        {
            //Arrange
            ExtendedDatabase dataBase = CreateExtendedDatabase(peopleCount, id, name);
            Person newPerson = new Person(id, name);

            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => dataBase.Add(newPerson),
                                    "There are more than one people with same ids!");
        }

        [Test]
        [TestCase(15, 123456789, "Viktor", 14)]
        public void RemoveMethodShouldRemoveTheLastElementOfTheDatabaseArray(
                int peopleCount,
                long id,
                string name,
                int expectedDatabaseCount)
        {
            //Arrange
            ExtendedDatabase dataBase = CreateExtendedDatabase(peopleCount, id, name);

            //Act
            dataBase.Remove();
            int expectedCount = expectedDatabaseCount;
            int actualCount = dataBase.Count;

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount),
                        "Remove method does not work properly! The count of the elements in the Database is not as expected!");
            Assert.Throws<InvalidOperationException>(() => dataBase.FindById(id + peopleCount - 1), "Person was not removed!");
        }

        [Test]
        public void RemoveMethodShouldThrowAnExceptionIfDatabaseIsEmpty()
        {
            //Arrange
            ExtendedDatabase dataBase = new ExtendedDatabase();

            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => dataBase.Remove(), "Remove method works on an empty database!");
        }
        [Test]
        [TestCase(15, 123456789, "Viktor")]
        public void FindByUsernameMethodShouldReturnAPersonFromTheDatabaseWithTheSameUsername(
                int peopleCount,
                long id,
                string name)
        {
            //Arrange
            ExtendedDatabase dataBase = CreateExtendedDatabase(peopleCount, id, name);

            //Act
            Person personWanted = dataBase.FindByUsername(name + "a");

            //Assert
            Assert.That(personWanted, Is.Not.Null,
                        "Tested method returned null!");
            Assert.That(personWanted.Id, Is.EqualTo(id), "Founded person is not the same!");
        }

        [Test]
        [TestCase(15, 123456789, "Viktor")]
        public void FindByUsernameMethodShouldThrowAnExceptionIfThereIsNotAPersonWithTheGivenNameInTheDatabase(
                int peopleCount,
                long id,
                string name)
        {
            //Arrange
            ExtendedDatabase dataBase = CreateExtendedDatabase(peopleCount, id, name);

            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => dataBase.FindByUsername(name.ToLower()));
        }

        [Test]
        [TestCase(15, 123456789, "Viktor")]
        public void FindByUsernameMethodShouldThrowAnExceptionIfTheGivenNameIsNull(
                int peopleCount,
                long id,
                string name)
        {
            //Arrange
            ExtendedDatabase dataBase = CreateExtendedDatabase(peopleCount, id, name);

            //Act-Assert
            Assert.Throws<ArgumentNullException>(() => dataBase.FindByUsername(null));
        }
        public void FindByIdMethodShouldReturnAPersonFromTheDatabaseWithTheSameId(
                int peopleCount,
                long id,
                string name)
        {
            //Arrange
            ExtendedDatabase dataBase = CreateExtendedDatabase(peopleCount, id, name);

            //Act
            Person personWanted = dataBase.FindById(id);

            //Assert
            Assert.That(personWanted, Is.Not.Null,
                        "Tested method returned null!");
            Assert.That(personWanted.UserName, Is.EqualTo(name + "a"), "Founded person is not the same!");
        }

        [Test]
        [TestCase(15, 123456789, "Viktor")]
        public void FindByIdMethodShouldThrowAnExceptionIfThereIsNotAPersonWithTheGivenIdInTheDatabase(
                int peopleCount,
                long id,
                string name)
        {
            //Arrange
            ExtendedDatabase dataBase = CreateExtendedDatabase(peopleCount, id, name);

            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => dataBase.FindById(id - 1));
        }

        [Test]
        [TestCase(15, 123456789, "Viktor")]
        public void FindByIdMethodShouldThrowAnExceptionIfTheGivenIdIsNegative(
                int peopleCount,
                long id,
                string name)
        {
            //Arrange
            ExtendedDatabase dataBase = CreateExtendedDatabase(peopleCount, id, name);

            //Act-Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => dataBase.FindById(id * -1));
        }
        private Person[] CreatePersonArray(int peopleCount, long id, string name)
        {
            Person[] people = new Person[peopleCount];
            for (int i = 0; i < people.Length; i++)
            {
                id += i;
                name += "a";
                people[i] = new Person(id, name);
            }
            return people;
        }
        private ExtendedDatabase CreateExtendedDatabase(int peopleCount, long id, string name)
        {
            Person[] people = CreatePersonArray(peopleCount, id, name);
            ExtendedDatabase dataBase = new ExtendedDatabase(people);
            return dataBase;
        }
    }
}