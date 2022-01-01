using MarsRover.App.Location;
using MarsRover.App.Location.Dependencies;
using System;
using System.Collections.Generic;

namespace MarsRover.App.Obstructions
{
    internal class ObstructedGridProvider : IObstacleProvider
    {
        private List<Position> obstructions;

        public ObstructedGridProvider(int areaWidth, int areaHeight)
        {
            obstructions = new List<Position>();
            var r = new Random();

            for (int i = 0; i < 4; i++)
            {
                var xCoord = r.Next(1, areaWidth);
                var yCoord = r.Next(1, areaHeight);

                obstructions.Add(new Position(xCoord, yCoord));
            }
        }

        public IReadOnlyCollection<Position> GetObstructions() => obstructions;
    }
}