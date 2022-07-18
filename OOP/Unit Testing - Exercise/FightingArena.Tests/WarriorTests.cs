using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Viktor", 50, 100)]
        [TestCase("Sasho", 60, 90)]
        public void ConstructorShouldSetAllTheDataCorrectly(string name, int damage, int hp)
        {
            //Arrange
            Warrior warrior = new Warrior(name, damage, hp);
            //Act
            string expectedName = name;
            int expectedDamage = damage;
            int expectedHP = hp;
            //Assert
            Assert.AreEqual(warrior.Name, expectedName);
            Assert.AreEqual(warrior.Damage, expectedDamage);
            Assert.AreEqual(warrior.HP, expectedHP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorShouldThrowExceptionIfNameIsNullOrWhitespace(string name)
        {

            //Act-Assert
            Assert.Throws<ArgumentException>(() => new Warrior(name, 50, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void ConstructorShouldThrowExceptionIfDamageIsZeroOrNegative(int damage)
        {

            //Act-Assert
            Assert.Throws<ArgumentException>(() => new Warrior("Kiro", damage, 100));
        }

        [Test]
        [TestCase(-5)]
        public void ConstructorShouldThrowExceptionIfHPIsNegative(int hp)
        {

            //Act-Assert
            Assert.Throws<ArgumentException>(() => new Warrior("Kiro", 50, hp));
        }

        [Test]
        [TestCase("Viktor", 50, 30)]
        [TestCase("Gosho", 60, 29)]
        public void AttackMethodShouldThrowAnExceptionIfThisWarriorDoesNotHaveTheMinimumHPReqiured(string name, int damage, int hp)
        {
            //Arrange
            Warrior attacker = new Warrior(name, damage, hp);
            Warrior warriorToBeAttacked = new Warrior("Sasho", hp - 1, 100);
            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warriorToBeAttacked));
        }

        [Test]
        [TestCase("Viktor", 50, 50)]
        [TestCase("Gosho", 60, 100)]
        public void AttackMethodShouldThrowAnExceptionIfTheAttackedWarriorDoesNotHaveTheMinimumHPReqiured(string name, int damage, int hp)
        {
            //Arrange
            Warrior attacker = new Warrior(name, damage, hp);
            Warrior warriorToBeAttacked = new Warrior("Sasho", hp - 1, 30);
            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warriorToBeAttacked));
        }

        [Test]
        [TestCase("Viktor", 50, 50)]
        [TestCase("Gosho", 60, 100)]
        public void AttackMethodShouldThrowAnExceptionIfThisWarriorHaveLessHPThanTheDamageOfTheAttackedOne(string name, int damage, int hp)
        {
            //Arrange
            Warrior attacker = new Warrior(name, damage, hp);
            Warrior warriorToBeAttacked = new Warrior("Sasho", hp + 1, hp);
            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warriorToBeAttacked));
        }

        [Test]
        [TestCase("Viktor", 90, 100)]
        [TestCase("Gosho", 60, 100)]
        public void AttackMethodShouldDecreaseAttackerHPWithTheAttackedWarriorDamageValue(string name, int damage, int hp)
        {
            //Arrange
            Warrior attacker = new Warrior(name, damage, hp);
            Warrior warriorToBeAttacked = new Warrior("Sasho", hp - 1, hp);
            //Act
            attacker.Attack(warriorToBeAttacked);
            int expectedAttackerHPAfterBattle = 1;
            //Assert
            Assert.That(attacker.HP, Is.EqualTo(expectedAttackerHPAfterBattle));
        }

        [Test]
        [TestCase("Viktor", 90, 100)]
        [TestCase("Gosho", 60, 100)]
        public void AttackMethodShouldSetAttackedWarriorHPToZeroIfHisHPIsLowerThanTheDamageOfTheAttacker(string name, int damage, int hp)
        {
            //Arrange
            Warrior attacker = new Warrior(name, damage, hp);
            Warrior warriorToBeAttacked = new Warrior("Sasho", hp - 1, damage - 1);
            //Act
            attacker.Attack(warriorToBeAttacked);
            int expectedHPOfTheAttackedWarrior = 0;
            //Assert
            Assert.That(warriorToBeAttacked.HP, Is.EqualTo(expectedHPOfTheAttackedWarrior));
        }

        [Test]
        [TestCase("Viktor", 90, 100)]
        [TestCase("Gosho", 60, 100)]
        public void AttackMethodShouldDecreaseAttackedWarriorHPWithTheAttackerDamageValueIfTheAttackedWarriorHPIsGreaterThanTheAttackerDamageValue
            (string name, int damage, int hp)
        {
            //Arrange
            Warrior attacker = new Warrior(name, damage, hp);
            Warrior warriorToBeAttacked = new Warrior("Sasho", hp - 1, damage + 1);
            //Act
            attacker.Attack(warriorToBeAttacked);
            int expectedHPOfTheAttackedWarrior = 1;
            //Assert
            Assert.That(warriorToBeAttacked.HP, Is.EqualTo(expectedHPOfTheAttackedWarrior));
        }

    }
}