using System.Collections.Generic;

namespace MarsRover.App
{
    internal class NoObstructionProvider : IObstacleProvider
    {
        public IReadOnlyCollection<Position> GetObstructions()
        {
            return new List<Position>();
        }
    }
}