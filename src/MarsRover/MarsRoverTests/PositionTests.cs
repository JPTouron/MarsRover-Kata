using AutoFixture;
using Xunit;

namespace MarsRover.App
{
    public class PositionTests
    {


        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 4)]
        [InlineData(3, -4)]
        [InlineData(-5, 6)]
        [InlineData(-10, -4)]
        public void WhenCreated_CoordinatesMustBeProvided(int xCoord, int yCoord)
        {
            var pos = new Position(xCoord, yCoord);

            Assert.Equal(xCoord, pos.x);
            Assert.Equal(yCoord, pos.y);
            Assert.Equal($"{xCoord},{yCoord}", pos.ToString());
        }

        [Theory]
        [InlineData(0, 0, 0, 1)]
        [InlineData(3, 0, 3, 1)]
        [InlineData(0, -2, 0, -1)]
        [InlineData(6, -5, 6, -4)]
        public void WhenOneStepIncreasedOnYAxis_ThenNewPositionIsReturnedWithYCoordinateIsIncreasedByOne(int xCoord, int yCoord, int expectedXCoord, int expectedYCoord)
        {
            var pos = new Position(xCoord, yCoord);
            var newPos = pos.IncreaseOneStepOnYAxis();

            Assert.Equal(newPos.x, expectedXCoord);
            Assert.Equal(newPos.y, expectedYCoord);
            Assert.NotEqual(pos, newPos);
        }

        [Theory]
        [InlineData(0, 0, 0, -1)]
        [InlineData(3, 0, 3, -1)]
        [InlineData(0, -2, 0, -3)]
        [InlineData(6, -5, 6, -6)]
        public void WhenOneStepDecreasedOnYAxis_ThenNewPositionIsReturnedWithYCoordinateIsDecreasedByOne(int xCoord, int yCoord, int expectedXCoord, int expectedYCoord)
        {
            var pos = new Position(xCoord, yCoord);
            var newPos = pos.DecreaseOneStepOnYAxis();

            Assert.Equal(newPos.x, expectedXCoord);
            Assert.Equal(newPos.y, expectedYCoord);
            Assert.NotEqual(pos, newPos);
        }

        [Theory]
        [InlineData(0, 0, 1, 0)]
        [InlineData(3, 0, 4, 0)]
        [InlineData(-2, -2, -1, -2)]
        [InlineData(-7, -5, -6, -5)]
        public void WhenOneStepIncreasedOnXAxis_ThenNewPositionIsReturnedWithXCoordinateIsIncreasedByOne(int xCoord, int yCoord, int expectedXCoord, int expectedYCoord)
        {
            var pos = new Position(xCoord, yCoord);
            var newPos = pos.IncreaseOneStepOnXAxis();

            Assert.Equal(newPos.x, expectedXCoord);
            Assert.Equal(newPos.y, expectedYCoord);
            Assert.NotEqual(pos, newPos);
        }

        [Theory]
        [InlineData(0, 0, -1, 0)]
        [InlineData(3, 0, 2, 0)]
        [InlineData(-2, -2, -3, -2)]
        [InlineData(-7, -5, -8, -5)]
        public void WhenOneStepDecreasedOnXAxis_ThenNewPositionIsReturnedWithXCoordinateIsDecreasedByOne(int xCoord, int yCoord, int expectedXCoord, int expectedYCoord)
        {
            var pos = new Position(xCoord, yCoord);
            var newPos = pos.DecreaseOneStepOnXAxis();

            Assert.Equal(newPos.x, expectedXCoord);
            Assert.Equal(newPos.y, expectedYCoord);
            Assert.NotEqual(pos, newPos);
        }


        [Fact]
        public void WhenComparingPositionsWithSameCoordinates_ThenPositionsAreEqual()
        {

            var fixture = new Fixture();
            var position = fixture.Create<Position>();
            var position2 = new Position(position.x, position.y);


            Assert.Equal(position, position2);

        }


        [Fact]
        public void WhenComparingPositionsWithDifferentCoordinates_ThenPositionsAreNotEqual()
        {

            var fixture = new Fixture();
            var position = fixture.Create<Position>();
            var randomFactor = fixture.Create<int>();
            var position2 = new Position(position.x * randomFactor, position.y * randomFactor);


            Assert.NotEqual(position, position2);

        }
    }
}