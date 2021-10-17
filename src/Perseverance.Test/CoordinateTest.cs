using NUnit.Framework;
using Perseverance.Domain.Entities;

namespace Perseverance.Test
{
    public class CoordinateTest
    {
        [Test]
        public void CoordinateShouldCreateInRightWay()
        {
            //Arrange
            int expectedX = 3;
            int expectedY = 55;

            //Acts
            Coordinate coordinate = new Coordinate(expectedX, expectedY);

            //Asserts
            Assert.AreEqual(expectedX, coordinate.X);
            Assert.AreEqual(expectedY, coordinate.Y);

        }
    }
}
