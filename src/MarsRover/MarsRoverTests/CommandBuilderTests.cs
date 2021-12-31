using Xunit;

namespace MarsRover.App
{
    public class CommandBuilderTests
    {
        [Fact]
        public void WhenBuilt_ThenAStringIsReturned()
        {
            var builder = new CommandBuilder();
            Assert.IsType<string>(builder.Build());
        }

        [Fact]
        public void WhenMoveForwardCommandAdded_ThenTheForwardCommandIsBuilt()
        {
            var expectedForwardCommand = "F";

            var builder = new CommandBuilder();
            builder.AddMoveForward();

            Assert.Equal(expectedForwardCommand, builder.Build());
        }

        [Fact]
        public void WhenMoveBackwardCommandAdded_ThenTheBackwardCommandIsBuilt()
        {
            var expectedBackwardCommand = "B";

            var builder = new CommandBuilder();
            builder.AddMoveBackward();

            Assert.Equal(expectedBackwardCommand, builder.Build());
        }

        [Fact]
        public void WhenTurnRightCommandAdded_ThenTheRightCommandIsBuilt()
        {
            var expectedRightCommand = "R";

            var builder = new CommandBuilder();
            builder.AddTurnRight();

            Assert.Equal(expectedRightCommand, builder.Build());
        }

        [Fact]
        public void WhenTurnLeftCommandAdded_ThenTheLeftCommandIsBuilt()
        {
            var expectedLeftCommand = "L";

            var builder = new CommandBuilder();
            builder.AddTurnLeft();

            Assert.Equal(expectedLeftCommand, builder.Build());
        }

        [Fact]
        public void WhenMultipleCommandsAdded_ThenTheCompleteCommandIsBuilt()
        {
            var expectedLeftCommand = "LFBRLBFL";

            var builder = new CommandBuilder();
            builder.AddTurnLeft();
            builder.AddMoveForward();
            builder.AddMoveBackward();
            builder.AddTurnRight();
            builder.AddTurnLeft();
            builder.AddMoveBackward();
            builder.AddMoveForward();
            builder.AddTurnLeft();

            Assert.Equal(expectedLeftCommand, builder.Build());
        }
    }
}