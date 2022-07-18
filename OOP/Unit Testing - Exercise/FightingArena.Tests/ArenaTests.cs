
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldCreateACollectionsOfWarriors()
        {
            //Arrange
            Arena arena = new Arena();
            //Act-Assert
            Assert.That(arena.Warriors, Is.Not.Null);
        }

        [Test]
        [TestCase(5, "Viktor")]
        public void CountProperyShouldReturnTheCountInTheArenaPrivateCollection(int initialCount, string name)
        {
            //Arrange
            Arena arena = new Arena();
            for (int i = 0; i < initialCount; i++)
            {
                name += "a";
                arena.Enroll(new Warrior(name, 50, 100));
            }

            //Act
            int expectedWarriorsCount = initialCount;
            //Assert
            Assert.That(arena.Count, Is.EqualTo(expectedWarriorsCount));

        }

        [Test]
        [TestCase("Viktor")]
        public void EnrollMethodShouldThrowExceptionIfThereIsAlreadyAWarriorWithTheSameNameInTheCollectionOfTheArena(string name)
        {
            //Arrange
            Warrior warrior1 = new Warrior(name, 10, 100);
            Warrior warrior2 = new Warrior(name, 50, 80);
            Arena arena = new Arena();
            //Act
            arena.Enroll(warrior1);
            //Assert
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior2));

        }

        [Test]
        [TestCase("Viktor")]
        public void EnrollMethodShouldAddTheGivenWarriorToTheCollectionOfTheArena(string name)
        {
            //Arrange
            Arena arena = new Arena();
            arena.Enroll(new Warrior(name, 50, 100));

            //Act
            int expectedWarriorsCount = 1;
            var isWarriorEnrolled = arena.Warriors.Any(x => x.Name == name);
            //Assert
            Assert.That(arena.Count, Is.EqualTo(expectedWarriorsCount));
            Assert.IsTrue(isWarriorEnrolled);

        }

        [Test]
        [TestCase("Viktor", "Sasho")]
        [TestCase("Sasho", "Viktor")]
        public void FightAttackShouldThrowAnExceptionIfAnyOfTheGivenWarriorsIsNull(string attackerName, string defenderName)
        {
            //Arrange
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Viktor", 50, 100));
            arena.Enroll(new Warrior("Gosho", 60, 90));
            arena.Enroll(new Warrior("Pesho", 70, 85));
            arena.Enroll(new Warrior("Tosho", 75, 40));
            arena.Enroll(new Warrior("Vais", 30, 100));
            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName));
        }

        [Test]
        [TestCase("Viktor", "Sasho")]
        [TestCase("Sasho", "Viktor")]
        public void FightAttackShouldNotThrowAnExceptionIfBothOfTheGivenWarriorsAreInTheCollectionOfTheArena(string attackerName, string defenderName)
        {
            //Arrange
            Arena arena = new Arena();
            arena.Enroll(new Warrior(attackerName, 50, 100));
            arena.Enroll(new Warrior("Gosho", 60, 90));
            arena.Enroll(new Warrior("Pesho", 70, 85));
            arena.Enroll(new Warrior("Tosho", 75, 40));
            arena.Enroll(new Warrior("Vais", 30, 100));
            arena.Enroll(new Warrior(defenderName, 50, 100));

            //Act
            arena.Fight(attackerName, defenderName);
            int attackerHPLeft = arena.Warriors.FirstOrDefault(x => x.Name == attackerName).HP;
            int defenderHPLeft = arena.Warriors.FirstOrDefault(x => x.Name == defenderName).HP;

            //Assert
            Assert.That(attackerHPLeft, Is.EqualTo(50));
            Assert.That(defenderHPLeft, Is.EqualTo(50));
        }
    }
}
