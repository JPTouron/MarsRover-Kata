using MarsRover.App.Location.Dependencies;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.App.Location
{
    public partial class Grid
    {
        private abstract class PositionTranslator
        {
            protected readonly int areaWidth;
            protected readonly int areaHeight;
            protected readonly IReadOnlyCollection<Position> obstructions;

            public PositionTranslator(int areaWidth, int areaHeight, IObstacleProvider obstacleProvider)
            {
                this.areaWidth = areaWidth;
                this.areaHeight = areaHeight;
                obstructions = obstacleProvider.GetObstructions();
            }

            protected bool IsPositionBlocked(int x, int y)
            {
                return obstructions.Any(p => p.X == x && p.Y == y);
            }

            protected Position IncreaseOneStepOnXAxes(Position currentPosition)
            {
                var newXCoord = currentPosition.NextXCoordinate;

                if (newXCoord > areaWidth)
                    newXCoord = 0;

                if (IsPositionBlocked(newXCoord, currentPosition.Y))
                {
                    return currentPosition;
                }
                else
                {
                    return currentPosition.SetX(newXCoord);
                }
            }

            protected Position IncreaseOneStepOnYAxes(Position currentPosition)
            {
                var newYCoord = currentPosition.NextYCoordinate;

                if (newYCoord > areaHeight)
                    newYCoord = 0;

                if (IsPositionBlocked(currentPosition.X, newYCoord))
                {
                    return currentPosition;
                }
                else
                {
                    return currentPosition.SetY(newYCoord);
                }
            }

            protected Position DecreaseOneStepOnXAxes(Position currentPosition)
            {
                var newXCoord = currentPosition.PreviousXCoordinate;

                if (newXCoord < 0)
                    newXCoord = areaWidth;

                if (IsPositionBlocked(newXCoord, currentPosition.Y))
                {
                    return currentPosition;
                }
                else
                {
                    return currentPosition.SetX(newXCoord);
                }
            }

            protected Position DecreaseOneStepOnYAxes(Position currentPosition)
            {
                var newYCoord = currentPosition.PreviousYCoordinate;

                if (newYCoord < 0)
                    newYCoord = areaHeight;

                if (IsPositionBlocked(currentPosition.X, newYCoord))
                {
                    return currentPosition;
                }
                else
                {
                    return currentPosition.SetY(newYCoord);
                }
            }
        }
    }
}