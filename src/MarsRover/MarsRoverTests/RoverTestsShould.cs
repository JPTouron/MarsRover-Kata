using Xunit;

namespace MarsRoverTests
{
    public class RoverTestsShould
    {
        [Fact]
        public void BeCreatedWithInitialPosition()
        {
            var r = new Rover();

            var output = r.Execute("");

            Assert.Equal("0,0:N", output);
        }

        [Theory]
        [InlineData("R", "0,0:E")]
        [InlineData("RR", "0,0:S")]
        [InlineData("RRR", "0,0:W")]
        [InlineData("RRRR", "0,0:N")]
        [InlineData("L", "0,0:W")]
        [InlineData("LL", "0,0:S")]
        [InlineData("LLL", "0,0:E")]
        [InlineData("LLLL", "0,0:N")]
        public void Rotate(string command, string expectedOutput)
        {
            var r = new Rover();

            var output = r.Execute(command);

            Assert.Equal(expectedOutput, output);
        }
    }
}