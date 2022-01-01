using System.Collections.Generic;

namespace MarsRover.App.Location.Dependencies
{
    internal interface IObstacleProvider
    {
        IReadOnlyCollection<Position> GetObstructions();
    }
}