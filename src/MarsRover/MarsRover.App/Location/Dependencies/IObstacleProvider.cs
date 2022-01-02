using System.Collections.Generic;

namespace MarsRover.App.Location.Dependencies
{
    public interface IObstacleProvider
    {
        IReadOnlyCollection<Position> GetObstructions();
    }
}