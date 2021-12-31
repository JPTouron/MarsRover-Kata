using System;

namespace MarsRover.App
{
    internal class Coordinate
    {
        public readonly int x;
        public readonly int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{x},{y}";
        }

        public Coordinate IncreaseOneStepOnYAxis()
        {
            return new Coordinate(x, y + 1);
        }
        public Coordinate IncreaseOneStepOnXAxis()
        {
            return new Coordinate(x + 1, y);
        }

        public Coordinate DescreaseOneStepOnYAxis()
        {
            return new Coordinate(x, y - 1);
        }
        public Coordinate DescreaseOneStepOnXAxis()
        {
            return new Coordinate(x - 1, y);
        }
    }
}