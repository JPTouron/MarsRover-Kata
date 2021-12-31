using AutoFixture;
using AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarsRover.App
{
    public class RoverTests
    {
        private IFixture fixture;

        public RoverTests()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());
        }

        [Theory]
        [InlineData("L", 'W')]
        [InlineData("R", 'E')]
        [InlineData("LL", 'S')]
        [InlineData("RR", 'S')]
        [InlineData("LLL", 'E')]
        [InlineData("RRR", 'W')]
        [InlineData("LLLL", 'N')]
        [InlineData("RRRR", 'N')]
        public void WhenCommandToTurnIsInput_ThenTheRoverReturnsNewDirection(string commands, char expectedDirection)
        {
            var r = new Rover();

            var output = r.Execute(commands);
            var actualDirection = output.First();

            Assert.Equal(expectedDirection, actualDirection);
        }

        [Theory]
        [MemberData(nameof(TestDataProvider.GetInvalidCommand), MemberType = typeof(TestDataProvider))]
        public void WhenCommandInvalidCommandIsInput_ThenArgumentExceptionThrown(char command)
        {
            var r = new Rover();

            Assert.Throws<ArgumentException>(() => r.Execute(command.ToString()));
        }

        [Theory]
        [InlineData("F", 0, 1)]
        [InlineData("FF", 0, 2)]
        [InlineData("FFF", 0, 3)]
        [InlineData("B", 0, -1)]
        [InlineData("BB", 0, -2)]
        [InlineData("BBB", 0, -3)]
        [InlineData("FBBBFBB", 0, -3)]
        public void WhenCommandToMoveBackOrFowrwardIsInput_ThenTheRoverChangesCoordinate(string commands, int expectedXCoord, int expectedYCoord)
        {
            var expectedCoordinate = new Position(expectedXCoord, expectedYCoord);
            char expectedDirection = 'N';

            var r = new Rover();

            var output = r.Execute(commands);
            var actualDirection = output.First();
            var actualCoordinate = output.Split(":")[1];

            Assert.Equal(expectedDirection, actualDirection);
            Assert.Equal(actualCoordinate, expectedCoordinate.ToString());
        }

        private static class TestDataProvider
        {
            public static IEnumerable<object> GetInvalidCommand()
            {
                var validCommands = new List<char> { 'L', 'R', 'M' };

                return new List<object[]> { new object[] { RandomCharacter(validCommands) } };
            }

            public static char RandomCharacter(List<char> validCommands)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var invalidCommands = chars.Except(validCommands).ToList();

                var random = new Random();

                return invalidCommands[random.Next(invalidCommands.Count)];
            }
        }
    }
}