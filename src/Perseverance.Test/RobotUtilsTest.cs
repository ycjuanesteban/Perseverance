using NUnit.Framework;
using Perseverance.Application.Utils;
using Perseverance.Domain.Entities;
using Perseverance.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Perseverance.Test
{
    public class RobotUtilsTest
    {
        //User instructions should not be null or empty
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void UserInstructionShouldNotBeNullOrEmpty(string userInstructions)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => new RobotUtils(userInstructions));
        }

        [Test]
        public void WorldShouldCreateInACorrectWay()
        {
            //Arrange
            string userInstructions = "5 3";
            int expectedXLimit = 5;
            int expectedYLimit = 3;

            RobotUtils utils = new RobotUtils(userInstructions);

            //Act
            Mars mars = utils.GetWorld();

            //Assert
            Assert.AreNotEqual(null, mars);
            Assert.AreEqual(expectedXLimit, mars.XLimit);
            Assert.AreEqual(expectedYLimit, mars.YLimit);
        }

        [Test]
        public void RobotShouldBeCreated()
        {
            //Arrange
            string userInstructions = $"5 3{Environment.NewLine}1 1 E{Environment.NewLine}RFRFRFRF";
            RobotUtils robotUtils = new RobotUtils(userInstructions);

            //Acts
            List<Robot> robots = robotUtils.GetRobots();

            //Asserts
            Assert.AreEqual(1, robots.Count);
        }

        [Test]
        public void RobotShouldBeInX1Y1DirectionEast()
        {
            //Arrange
            string userInstructions = $"5 3{Environment.NewLine}1 1 E{Environment.NewLine}RFRFRFRF";
            RobotUtils robotUtils = new RobotUtils(userInstructions);

            //Acts
            List<Robot> robots = robotUtils.GetRobots();

            //Asserts
            Robot robot = robots[0];
            Assert.AreEqual(1, robot.CurrentPosition.X);
            Assert.AreEqual(1, robot.CurrentPosition.Y);
            Assert.AreEqual(Direction.E, robot.Direction);
        }

        [Test]
        public void GetRobotsThrowExceptionByInstructionLength()
        {
            //Arrange
            string expectedExceptionMessage = "One of the instructions is bigger than 100 characters";
            string userInstructions = $"5 3{Environment.NewLine}1 1 E{Environment.NewLine}RFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRF";
            RobotUtils robotUtils = new RobotUtils(userInstructions);

            //Acts
            Exception ex = Assert.Throws<Exception>(() => robotUtils.GetRobots());

            //Asserts
            Assert.AreEqual(expectedExceptionMessage, ex.Message);
        }
    }
}
