using AutoFixture;
using AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarsRover.App
{
    public class CommandTests
    {
        private IFixture fixture;

        public CommandTests()
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
        public void WhenCommandToTurnIsInput_ThenTheRoverReturnsNewDirection(string command, char expectedDirection)
        {
            var r = new Rover();

            var output = r.Execute(command);
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