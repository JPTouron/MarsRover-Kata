using System;

namespace MarsRover.App
{
    internal class Position : IEquatable<Position>
    {
        public readonly int x;
        public readonly int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{x},{y}";
        }

        public Position IncreaseOneStepOnYAxes()
        {
            return new Position(x, y + 1);
        }

        public Position IncreaseOneStepOnXAxes()
        {
            return new Position(x + 1, y);
        }

        public Position DecreaseOneStepOnYAxes()
        {
            return new Position(x, y - 1);
        }

        public Position DecreaseOneStepOnXAxes()
        {
            return new Position(x - 1, y);
        }

        public bool Equals(Position? other)
        {
            var isOtherNotNull = other != null;

            return isOtherNotNull && x == other?.x && y == other.y;
        }
    }
}