using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarsRover.App
{

    public class MarsRoverTests
    {
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

        private static class TestDataProvider
        {
            public static string GetInvalidCommands()
            {




                var validCommands = new List<string> { "L", "R", "M" };

                return


            }
            public static char GetRandomCharacter(string text, Random rng)
            {
                int index = rng.Next(text.Length);
                return text[index];
            }
        }
        [Theory]
        [MemberData()]
        public void WhenCommandInvalidCommandIsInput_ThenArgumentExceptionThrown(string command)
        {
        }
    }
}
