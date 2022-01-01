using System.Collections.Generic;
using Xunit;

namespace MarsRover.App
{
    public class ObstructedGridProviderTests
    {

        [Fact]
        internal void WhenCreated_TakesDimensionsAndCreatesRandomBlockedPositions()
        {
            var areaWidth = 20;
            var areaHeight = 20;

            var provider = new ObstructedGridProvider(areaWidth, areaHeight);

            IReadOnlyCollection<Position> obstructions = provider.GetObstructions();

            Assert.NotNull(provider);
            Assert.NotEmpty(obstructions);
            foreach (var obstructedPosition in obstructions)
            {
                Assert.InRange(obstructedPosition.X, 1, areaWidth);
                Assert.InRange(obstructedPosition.Y, 1, areaHeight);
            }

        }

    }
}