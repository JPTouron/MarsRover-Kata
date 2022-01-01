using AutoFixture;
using Xunit;

namespace MarsRover.App
{
    public class RoverOutputTests
    {
        [Theory]
        [InlineData('N', 4, 5, false, "N:4,5")]
        [InlineData('E', 9, 4, false, "E:9,4")]
        [InlineData('W', 1, 5, false, "W:1,5")]
        [InlineData('S', 3, 7, false, "S:3,7")]
        public void WhenCreated_ThenTheProperOutputCanBeReturnedAsString(char direction, int xCoordinate, int yCoordinate, bool isNextPositionInTheDirectionBlocked, string expectedOutput)
        {
            var output = new RoverOutput(direction, new Position(xCoordinate, yCoordinate), isNextPositionInTheDirectionBlocked);
            Assert.Equal(expectedOutput, output.ToString());
        }

        [Fact]
        public void WhenTwoOutputsContainSameProperties_ThenTheyAreEqual() {

            var fix = new Fixture();
            var output1 =  fix.Create<RoverOutput>();
            var output2 =  new RoverOutput(output1.Direction, output1.Position, output1.IsNextPositionInTheDirectionBlocked);


            Assert.Equal(output1, output2);
            

        }
        [Fact]
        public void WhenTwoOutputsDoNotContainSameProperties_ThenTheyAreDifferent()
        {

            var fix = new Fixture();
            var output1 = fix.Create<RoverOutput>();
            var output2 = new RoverOutput(output1.Direction, output1.Position, !output1.IsNextPositionInTheDirectionBlocked);


            Assert.NotEqual(output1, output2);


        }
    }
}