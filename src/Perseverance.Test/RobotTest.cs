using NUnit.Framework;
using Perseverance.Domain.Entities;
using Perseverance.Domain.Enums;

namespace Perseverance.Test
{
    public class RobotTest
    {
        [Test]
        public void RobotSetupIsCorrect()
        {
            //Arrange
            Mars mars = new Mars(1, 2);
            Coordinate coordinate = new Coordinate(1, 2);
            Direction direction = Direction.W;

            //Act
            Robot robot = new Robot(coordinate, direction, mars);

            //Assert
            Assert.AreEqual(coordinate, robot.CurrentPosition);
            Assert.AreEqual(direction, robot.Direction);
        }

        [Test]
        public void RobotFinishInX3Y2DirectionN()
        {
            //Arrange
            Mars mars = new Mars(5, 3);
            Coordinate coordinate = new Coordinate(1, 1);
            Direction direction = Direction.E;
            string commands = "RFRFRFRF";

            Coordinate expectedCoordinate = new Coordinate(1, 1);
            Direction expectedDirection = Direction.E;

            //Act
            Robot robot = new Robot(coordinate, direction, mars);
            robot.SetCommands(commands);
            robot.ExecuteComands();

            //Assert
            Assert.AreEqual(expectedCoordinate.X, robot.CurrentPosition.X);
            Assert.AreEqual(expectedCoordinate.Y, robot.CurrentPosition.Y);
            Assert.AreEqual(expectedDirection, robot.Direction);
        }

        [Test]
        public void RobotIsLost()
        {
            //Arrange
            Mars mars = new Mars(5, 3);
            Coordinate coordinate = new Coordinate(3, 2);
            Direction direction = Direction.N;
            string commands = "FRRFLLFFRRFLL";

            //Act
            Robot robot = new Robot(coordinate, direction, mars);
            robot.SetCommands(commands);
            robot.ExecuteComands();

            //Assert
            Assert.AreEqual(true, robot.IsLost);
            Assert.AreEqual("3 3 N LOST", robot.ToString());
        }
    }
}
