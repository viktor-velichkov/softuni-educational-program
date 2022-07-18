namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [Test]
        [TestCase("Viktor", 50)]
        public void RobotConstructorShouldSetAllTheDataProperly(string name, int maximumBattery)
        {
            //Arrange
            Robot robot = new Robot(name, maximumBattery);
            //Assert
            Assert.AreEqual(name, robot.Name);
            Assert.AreEqual(maximumBattery, robot.Battery);
            Assert.AreEqual(maximumBattery, robot.MaximumBattery);
        }

        [Test]
        [TestCase(50)]
        public void RobotManagerConstructorShouldWorkProperly(int capacity)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(capacity);
            //Assert
            Assert.That(robotManager.Capacity, Is.EqualTo(capacity));
        }

        [Test]
        [TestCase(-50)]
        public void RobotManagerConstructorShouldThrowExceptionIfCapacityIsNegative(int capacity)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => new RobotManager(capacity));
        }

        [Test]
        [TestCase("Viktor", 50, 5, 1)]
        public void AddMethodShouldAddRobotsToTheRobotManagerRepository(
            string robotName,
            int robotBattery,
            int managerCapacity,
            int expectedCount)
        {
            //Arrange
            Robot robot = new Robot(robotName, robotBattery);
            RobotManager robotManager = new RobotManager(managerCapacity);
            //Assert before Act
            Assert.That(robotManager.Count, Is.EqualTo(0));
            //Act
            robotManager.Add(robot);
            //Assert
            Assert.That(robotManager.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        [TestCase("Viktor", 50, 5)]
        public void AddMethodShouldThrowExceptionIfThereIsARobotWithTheSameNameInTheManagerRepository(
            string robotName,
            int robotBattery,
            int managerCapacity)
        {
            //Arrange
            Robot robot = new Robot(robotName, robotBattery);
            RobotManager robotManager = new RobotManager(managerCapacity);

            //Act
            robotManager.Add(robot);
            //Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        [TestCase(new string[3] { "Viktor", "Stefan", "Petyr" }, new int[3] { 50, 60, 100 }, 2)]
        public void AddMethodShouldThrowExceptionIfTheCapacityOfTheManagerRepositoryIsAlreadyReached(
            string[] robotNames,
            int[] robotBatteries,
            int managerCapacity)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(managerCapacity);
            for (int i = 0; i < robotNames.Length - 1; i++)
            {
                robotManager.Add(new Robot(robotNames[i], robotBatteries[i]));
            }
            Robot robot = new Robot(robotNames[robotNames.Length - 1], robotBatteries[robotBatteries.Length - 1]);

            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        [TestCase(new string[3] { "Viktor", "Stefan", "Petyr" }, new int[3] { 50, 60, 100 }, 3)]
        public void RemoveMethodShouldRemoveARobotWithTheGivenNameFromTheManagerRepository(
            string[] robotNames,
            int[] robotBatteries,
            int managerCapacity)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(managerCapacity);
            for (int i = 0; i < robotNames.Length; i++)
            {
                robotManager.Add(new Robot(robotNames[i], robotBatteries[i]));
            }
            //Assert before Act
            Assert.That(robotManager.Count, Is.EqualTo(robotNames.Length));

            //Act
            robotManager.Remove(robotNames[0]);

            //Assert
            Assert.That(robotManager.Count, Is.EqualTo(robotNames.Length - 1));
        }

        [Test]
        [TestCase(new string[3] { "Viktor", "Stefan", "Petyr" }, new int[3] { 50, 60, 100 }, 3, "Stamat")]
        public void RemoveMethodShouldThrowAnExceptionIfThereIsNotAnyRobotWithTheGivenNameInTheManagerRepository(
            string[] robotNames,
            int[] robotBatteries,
            int managerCapacity,
            string robotToRemove)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(managerCapacity);
            for (int i = 0; i < robotNames.Length; i++)
            {
                robotManager.Add(new Robot(robotNames[i], robotBatteries[i]));
            }


            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(robotToRemove));
        }


        [Test]
        [TestCase("Viktor", 50, 3, "job", 20,30)]
        public void WorkMethodShouldDrainRobotsBatteryIfBatteryUsageIsValid(
            string robotName,
            int robotBattery,
            int managerCapacity,
            string job,
            int batteryUsage,
            int expectedBatteryValue)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(managerCapacity);
            Robot robot = new Robot(robotName, robotBattery);

            //Act
            robotManager.Add(robot);
            robotManager.Work(robotName,job,batteryUsage);

            //Act- Assert
            Assert.AreEqual(expectedBatteryValue, robot.Battery);
        }

        [Test]
        [TestCase(new string[3] { "Viktor", "Stefan", "Petyr" }, new int[3] { 50, 60, 100 }, 3, "job", 20, "Stamat")]
        public void WorkMethodShouldThrowsAnExceptionIfThereIsNotAnyRobotWithTheGivenNameInTheManagerRepository(
            string[] robotNames,
            int[] robotBatteries,
            int managerCapacity,
            string job,
            int batteryUsage,
            string robotToDoTheJob)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(managerCapacity);
            for (int i = 0; i < robotNames.Length; i++)
            {
                robotManager.Add(new Robot(robotNames[i], robotBatteries[i]));
            }

            //Act- Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robotToDoTheJob, job, batteryUsage));
        }

        [Test]
        [TestCase(new string[3] { "Viktor", "Stefan", "Petyr" }, new int[3] { 50, 60, 100 }, 3, "job", 120)]
        public void WorkMethodShouldThrowsAnExceptionIfGivenRobotDoesNotHaveEnoughBatteryPowerToDoTheJob(
            string[] robotNames,
            int[] robotBatteries,
            int managerCapacity,
            string job,
            int batteryUsage
            )
        {
            //Arrange
            RobotManager robotManager = new RobotManager(managerCapacity);
            for (int i = 0; i < robotNames.Length; i++)
            {
                robotManager.Add(new Robot(robotNames[i], robotBatteries[i]));
            }

            //Act- Assert
            for (int i = 0; i < robotNames.Length; i++)
            {
                Assert.Throws<InvalidOperationException>(() => robotManager.Work(robotNames[i], job, batteryUsage));
            }
        }

        [Test]
        [TestCase("Viktor", 50, 3, "job", 20)]
        public void ChargeMethodShouldSetBatteryOfTheGivenRobotToMaximum(
            string robotName,
            int robotBattery,
            int managerCapacity,
            string job,
            int batteryUsage)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(managerCapacity);
            Robot robot = new Robot(robotName, robotBattery);

            //Act
            robotManager.Add(robot);
            robotManager.Work(robotName, job, batteryUsage);
            robotManager.Charge(robotName);

            //Act- Assert
            Assert.AreEqual(robot.MaximumBattery, robot.Battery);
        }

        [Test]
        [TestCase(new string[3] { "Viktor", "Stefan", "Petyr" }, new int[3] { 50, 60, 100 }, 3, "Stamat")]
        public void ChargeMethodShouldThrowsAnExceptionIfThereIsNotAnyRobotWithTheGivenNameInTheManagerRepository(
        string[] robotNames,
        int[] robotBatteries,
        int managerCapacity,
        string robotToCharge)
        {
            //Arrange
            RobotManager robotManager = new RobotManager(managerCapacity);
            for (int i = 0; i < robotNames.Length; i++)
            {
                robotManager.Add(new Robot(robotNames[i], robotBatteries[i]));
            }

            //Act- Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge(robotToCharge));
        }
    }
}

