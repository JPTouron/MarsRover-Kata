using MarsRover.App.Location;
using MarsRover.App.Location.Dependencies;
using System.Collections.Generic;

namespace MarsRover.Tests.Stubs
{
    internal class SpecificObstructionProvider : IObstacleProvider
    {
        private readonly Position obstruction;

        public SpecificObstructionProvider(Position obstruction)
        {
            this.obstruction = obstruction;
        }

        public IReadOnlyCollection<Position> GetObstructions()
        {
            return new List<Position> { obstruction };
        }
    }
}