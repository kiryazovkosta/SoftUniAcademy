namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void CtorShouldCreateManagerWithValidCapacity()
        {
            RobotManager manager = new RobotManager(5);

            Assert.IsNotNull(manager);
            Assert.AreEqual(0, manager.Count);
            Assert.AreEqual(5, manager.Capacity);
        }

        [Test]
        public void CtorShouldThrowsExceptionInvalidCapacity()
        {
            var exception = Assert.Throws<ArgumentException>(() => new RobotManager(-1));
            Assert.AreEqual("Invalid capacity!", exception.Message);
        }

        [Test]
        public void AddShouldThrowsExceptionWhenRobotIsAlreadyAdded()
        {
            Robot robot1 = new Robot("Test", 100);
            Robot robot2 = new Robot("Test", 100);
            RobotManager manager = new RobotManager(5);
            string errorMessage = $"There is already a robot with name {robot2.Name}!";

            manager.Add(robot1);

            var exception = Assert.Throws<InvalidOperationException>(() => manager.Add(robot2));
            Assert.AreEqual(errorMessage, exception.Message);
        }

        [Test]
        public void AddShouldThrowsExceptionWhenMaximumCapacityIsReached()
        {
            Robot robot1 = new Robot("Test1", 100);
            Robot robot2 = new Robot("Test2", 100);
            RobotManager manager = new RobotManager(1);

            manager.Add(robot1);

            var exception = Assert.Throws<InvalidOperationException>(() => manager.Add(robot2));
            Assert.AreEqual("Not enough capacity!", exception.Message);
        }

        [Test]
        public void RemoveShouldThrowsExceptionIFRobotDoesNotExists()
        {
            string errorMessage = $"Robot with the name iRobot doesn't exist!";
            Robot robot = new Robot("Test", 100);
            RobotManager manager = new RobotManager(5);

            manager.Add(robot);

            var exception = Assert.Throws<InvalidOperationException>(() => manager.Remove("iRobot"));
            Assert.AreEqual(errorMessage, exception.Message);
        }

        [Test]
        public void RemoveShouldRemoveRobotFromManager()
        {
            Robot robot = new Robot("iRobot", 100);
            RobotManager manager = new RobotManager(5);
            manager.Add(robot);

            manager.Remove("iRobot");
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void WorkShouldThrowsExceptionIfRobotDoesNotExists()
        {
            string errorMessage = $"Robot with the name iRobot doesn't exist!";
            Robot robot = new Robot("Test", 100);
            RobotManager manager = new RobotManager(5);

            manager.Add(robot);

            var exception = Assert.Throws<InvalidOperationException>(() => manager.Work("iRobot", "work", 20));
            Assert.AreEqual(errorMessage, exception.Message);
        }

        [Test]
        public void WorkShouldThrowsExceptionWhenJobWantsMoreBatterThanRobotHave()
        {
            string errorMessage = "iRobot doesn't have enough battery!";
            Robot robot = new Robot("iRobot", 50);
            RobotManager manager = new RobotManager(5);

            manager.Add(robot);

            var exception = Assert.Throws<InvalidOperationException>(() => manager.Work("iRobot", "work", 60));
            Assert.AreEqual(errorMessage, exception.Message);
        }

        [Test]
        [TestCase(100, 60, 40)]
        [TestCase(50, 50, 0)]
        public void WorkShouldExcuteJobAndReduseRobotBattery(int battery, int job, int still)
        {
            Robot robot = new Robot("iRobot", battery);
            RobotManager manager = new RobotManager(5);

            manager.Add(robot);

            manager.Work("iRobot", "work", job);
            Assert.AreEqual(still, robot.Battery);
        }

        [Test]
        public void ChargeShouldThrowsExceptionWhenRobotDoesNotExists()
        {
            string errorMessage = $"Robot with the name iRobot doesn't exist!";
            Robot robot = new Robot("Test", 100);
            RobotManager manager = new RobotManager(5);

            manager.Add(robot);

            var exception = Assert.Throws<InvalidOperationException>(() => manager.Charge("iRobot"));
            Assert.AreEqual(errorMessage, exception.Message);
        }

        [Test]
        public void ChargeShouldChargeExistingRobotWithMaximum()
        {
            Robot robot = new Robot("iRobot", 100);
            RobotManager manager = new RobotManager(5);

            manager.Add(robot);
            manager.Work("iRobot", "Job", 50);
            int before = robot.Battery;

            manager.Charge("iRobot");
            int after = robot.Battery;

            Assert.AreEqual(50, before);
            Assert.AreEqual(100, after);
        }

    }
}

//public void Charge(string robotName)
//{
//    Robot robot = this.robots.FirstOrDefault(r => r.Name == robotName);

//    if (robot == null)
//    {
//        throw new InvalidOperationException($"Robot with the name {robotName} doesn't exist!");
//    }

//    robot.Battery = robot.MaximumBattery;
//}
