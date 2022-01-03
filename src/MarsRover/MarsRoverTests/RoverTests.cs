using Xunit;

namespace MarsRoverTests
{
    public class RoverTestsShouldBe
    {
        [Fact]
        public void CreatedWithInitialPosition()
        {
            var r = new Rover();

            var output =  r.Execute("");

            Assert.Equal("0,0:N", output);

        }
    }
}