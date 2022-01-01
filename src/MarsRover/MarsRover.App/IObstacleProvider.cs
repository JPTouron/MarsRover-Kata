using System.Collections.Generic;

namespace MarsRover.App
{
    internal interface IObstacleProvider
    {

        IReadOnlyCollection<Position> GetObstructions();

    }
}