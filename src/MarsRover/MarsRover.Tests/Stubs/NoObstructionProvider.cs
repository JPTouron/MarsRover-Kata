using MarsRover.App.Location;
using MarsRover.App.Location.Dependencies;
using System.Collections.Generic;

namespace MarsRover.Tests.Stubs
{
    internal class NoObstructionProvider : IObstacleProvider
    {
        public IReadOnlyCollection<Position> GetObstructions()
        {
            return new List<Position>();
        }
    }
}