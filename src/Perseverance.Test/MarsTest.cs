using NUnit.Framework;
using Perseverance.Domain.Entities;
using System.Collections.Generic;

namespace Perseverance.Test
{
    public class MarsTest
    {

        [Test]
        public void MarsSetUpIsCorrect()
        {
            //Arrange
            int expectedX = 1;
            int expectedY = 3;

            //Act
            Mars mars = new Mars(expectedX, expectedY);

            //Assert
            Assert.AreEqual(expectedX, mars.XLimit);
            Assert.AreEqual(expectedY, mars.YLimit);
        }

        [Test]
        public void MarsValidateToNoAddDuplicateCoordinate()
        {
            //Arrange
            int expectedX = 1;
            int expectedY = 3;
            Mars mars = new Mars(expectedX, expectedY);

            //Act
            mars.AddPointToScente(new Coordinate(1, 1));
            bool coordinateExist = mars.IsScenteThisPoint(new Coordinate(1, 1));

            //Assert
            Assert.AreEqual(true, coordinateExist);
        }

        [Test]
        public void MarsAddTheCorrectQuantityOfCoordinates()
        {
            //Arrange
            int expectedX = 1;
            int expectedY = 3;
            int expectedQuantity = 3;
            Mars mars = new Mars(expectedX, expectedY);

            //Act
            mars.AddPointToScente(new Coordinate(1, 1));
            mars.AddPointToScente(new Coordinate(1, 2));
            mars.AddPointToScente(new Coordinate(1, 3));
            mars.AddPointToScente(new Coordinate(1, 1));

            List<Coordinate> coordinates = mars.GetFinalScents();

            //Assert
            Assert.AreEqual(expectedQuantity, coordinates.Count);
        }
    }
}
